﻿using System;
using MimeKit;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vacanze_back.VacanzeApi.Common.Exceptions;
using vacanze_back.VacanzeApi.Common.Exceptions.Grupo1;
using vacanze_back.VacanzeApi.Common.Entities;
using vacanze_back.VacanzeApi.Common.Entities.Grupo1;
using vacanze_back.VacanzeApi.LogicLayer.Command;
using vacanze_back.VacanzeApi.LogicLayer.Command.Grupo1;
using vacanze_back.VacanzeApi.LogicLayer.DTO.Grupo1;
using vacanze_back.VacanzeApi.LogicLayer.Mapper;
using vacanze_back.VacanzeApi.LogicLayer.Mapper.Grupo1;

namespace vacanze_back.VacanzeApi.Services.Controllers.Grupo1
{
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    [ApiController]
    public class EmailController : ControllerBase
    {

        private readonly ILogger<EmailController> _logger;

        public EmailController(ILogger<EmailController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        /// <summary>
        ///     Controller para cambiar la clave del usuario
        /// </summary>
        /// <param name="loginDTO">Objeto login a cambiar su clave</param>
        /// <returns>Objeto tipo Entity con los datos del usuario luego de cambiar su clave</returns>
        /// <exception cref="PasswordRecoveryException">El objeto a retornar es nulo</exception>
        /// <exception cref="DatabaseException">Algun error con la base de datos</exception>
       
        //POST : /api/Email
        public ActionResult<LoginDTO> Recovery([FromBody] LoginDTO loginDTO)
        {
            try{
                LoginMapper LoginMapper = MapperFactory.createLoginMapper();
                Entity entity = LoginMapper.CreateEntity(loginDTO);
                RecoveryPasswordCommand command = CommandFactory.RecoveryPasswordCommand((Login) entity);
                command.Execute();
                    
                Login objUser = command.GetResult();

                if (objUser != null){
                    Console.WriteLine("Correo del usuario que modifico: ");
                    Console.WriteLine(objUser.email);
                    Console.WriteLine("Clave del usuario modificada: ");
                    Console.WriteLine(objUser.password);
                    
                    //logica correo
                    var message = new MimeMessage();
                    //From Address
                    message.From.Add(new MailboxAddress("Vacanze Administracion", "vacanzeucab@gmail.com"));
                    //To Address
                    message.To.Add(new MailboxAddress("Usuario", address: objUser.email));
                    //Subject
                    message.Subject = "Recuperacion De Contraseña : ";

                    message.Body = new TextPart("plain"){
                    Text = "Su contraseña nueva: " + objUser.password
                    };


                    using (var client = new MailKit.Net.Smtp.SmtpClient()){
                        client.CheckCertificateRevocation = false;
                        client.Connect("smtp.gmail.com", 587);
                        client.Authenticate("hombrehealth111@gmail.com", "_Gx123456");
                        client.Send(message);
                        client.Disconnect(true);
                        client.Dispose();
                    }
                    LoginDTO ldto = LoginMapper.CreateDTO(objUser);
                    return Ok(ldto);
                }
                else{ 
                    return BadRequest(new { message = "Correo invalido." });

                }
            }
            catch(DatabaseException ex){
                _logger?.LogError(ex, "Database exception cuando se intenta mandar el correo con la nueva clave al cliente");
                return StatusCode(500, ex.Message);
            }
            catch(PasswordRecoveryException ){
                return BadRequest(new { message = "Correo invalido." });
            }
        }
    }
}
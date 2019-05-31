using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using vacanze_back.VacanzeApi.Common.Entities.Grupo2;
using vacanze_back.VacanzeApi.Common.Exceptions;
using vacanze_back.VacanzeApi.Persistence.Repository.Grupo2;

namespace vacanze_back.VacanzeApi.Services.Controllers.Grupo2
{
    [Produces("application/json")] 
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET api/users
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetEmployees()
        {
            var users = new List<User>();
            try
            {
                users = UserRepository.GetEmployees();
            }
            catch (DatabaseException)
            {
                return BadRequest("Error obteniendo los empleados");
            }
            return users;
        }

        // GET api/values/5
//        [HttpGet("{id}")]
//        public ActionResult<string> Get(int id)
//        {
//            return "value";
//        }

        // POST api/users
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            try
            {
                user.Validate();
                UserRepository.VerifyEmail(user.Email);
                user = UserRepository.AddUser(user);
                foreach(var roles in user.Roles)
                {
                    UserRepository.AddUser_Role(user.Id, roles.Id);
                }
            }
            catch (Exception e)
            {
                BadRequest(e.Message);
            }
            return user;
        }

        // PUT api/values/5
//        [HttpPut("{id}")]
//        public void Put(int id, [FromBody] string value)
//        {
//        }
//
//        // DELETE api/values/5
//        [HttpDelete("{id}")]
//        public void Delete(int id)
//        {
//        }
    }
}
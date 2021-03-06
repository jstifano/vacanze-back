using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using vacanze_back.VacanzeApi.Common.Entities.Grupo10;
using vacanze_back.VacanzeApi.Persistence.Repository.Grupo10;
using vacanze_back.VacanzeApi.Persistence.DAO.Grupo10;
using vacanze_back.VacanzeApi.Common.Exceptions;
using vacanze_back.VacanzeApi.Common.Entities;
using vacanze_back.VacanzeApi.Common.Exceptions.Grupo10;
namespace vacanze_back.VacanzeApi.Services.Controllers.Grupo10{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    [ApiController]
    public class CommentController: ControllerBase
     {
        [Consumes("application/json")]
        [HttpPost]    
        public IActionResult AddTravel([FromBody] Comment _comment)
        { // esto es add comment, pero se uso con el nombre addtravel
          // este metodo añade comentarios del usuario a la BD
            try{
                Icomment comment= new Commentdao(); 
                int id = comment.addcomment(_comment);
                return Ok(_comment);
            }catch(RequiredAttributeException ex){
                return StatusCode(400,ex.Message);
            }catch(UserNotFoundException ex){
                return StatusCode(404,ex.Message);
            }catch(InternalServerErrorException ex){
                return StatusCode(500, ex.Message);
            }catch(Exception){
                return StatusCode(400);
            }
        }

        [HttpGet("{userId}")]
        public ActionResult<IEnumerable<Comment>> GetComment(int userId)
        {   // esta funcion te trae todo el contenido de un comentario, dependiendo del id del usuario
            List<Comment> comments= new List<Comment>();
            Icomment commentdao =new Commentdao();
            try{
                comments = commentdao.Getcomment(userId);
                return Ok(comments);
            }catch(WithoutExistenceOfTravelsException ex){
                return StatusCode(404,ex.Message);
            }catch(UserNotFoundException ex){
                return StatusCode(400,ex.Message);
            }catch(InternalServerErrorException ex){
                return StatusCode(500, ex.Message);
            }catch(Exception){
                return StatusCode(400);
            }
        }

        [Consumes("application/json")]
        [HttpPut]
        public IActionResult UpdateComment([FromBody] Comment comment)
        {   // este metodo actualiza un comentario especificado
            try{
                Icomment commentdao =new Commentdao();
                if(commentdao.Updatecomment(comment))
                    return Ok("Las modificaciones fueron realizadas exitosamente");
                else
                    return StatusCode(400);
            }catch(InternalServerErrorException ex){
                return StatusCode(500, ex.Message);
            }catch(Exception){
                return StatusCode(400);
            }
        }

        [Consumes("application/json")]
        [HttpDelete("delete/{id}")]
        public IActionResult Deletecomment ([FromBody] int commentId)
        {  // borra el comentario especificado mediante su id
            try
            {
                Icomment commentdao =new Commentdao();
                 int  i =  commentdao.Deletecomment(commentId);
                if (i==0){
                    return Ok ("no se elminno ");
                }
                return Ok("se elimino");
            }
            catch (InvalidCastException)
            {
                throw new DeleteReservationException("el comentario no existe.");
            }
            catch (DatabaseException)
            {
                throw new DeleteReservationException("Error con la base de datos.");
            }
        }
     }
}

using System.Collections.Generic;
using System.Web.Http;
using Shared.Entities;
using System.Web.Http.Cors;
using System;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.Factories;
using BusinessLogicLayer.Interfaces;

namespace ApiServices.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CommentController : ApiController
    {
        /*
            Crear Comentario
            POST api/comment/
            {
		        "email":"u1@e.com",
                "text":"Este es un comentario"
            }
        */
        public async Task<IHttpActionResult> Post()
        {
            var rawMessage = await Request.Content.ReadAsStringAsync();
            dynamic entity = JObject.Parse(rawMessage);

            IBLComments clogic = BLFactory.GetBLComments();
            IBLUsers ulogic = BLFactory.GetBLUsers();
            if (null == entity["email"] || null == entity["text"])
            {
                return BadRequest("Campos erroneos");
            }                          
            try
            {
                string email = entity["email"];
                string text = entity["text"];
                User u = ulogic.getUser(email);
                Comment c = new Comment
                {
                    Id = Guid.NewGuid(),
                    Owner = u,
                    Text = text,
                    Comments = new List<Comment>()
                };
                clogic.AddComment(c);
                return Ok();
            }
            catch(Exception e)
            {
                return InternalServerError(e);
            }            
        }
    }
}
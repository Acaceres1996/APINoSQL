using System.Collections.Generic;
using System.Web.Http;
using Shared.Entities;
using System.Web.Http.Cors;
using System;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Factories;

namespace ApiServices.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AddCommentController : ApiController
    {
        /*
            Comentar comentario
            POST api/AddComment/
            {
		        "guid":"fc141a6d-9a66-4171-ac1a-e13eaeffbd6f",
                "email":"u1@e.com",
                "text":"Este es un comentario en un comentario"
            }
        */
        public async Task<IHttpActionResult> Post()
        {
            var rawMessage = await Request.Content.ReadAsStringAsync();
            dynamic entity = JObject.Parse(rawMessage);

            IBLComments clogic = BLFactory.GetBLComments();
            IBLUsers ulogic = BLFactory.GetBLUsers();
            string GUID = entity["guid"];
            string email = entity["email"];
            string text = entity["text"];
            if (null == entity["guid"] || null == entity["email"] || null == entity["text"])
            {
                return BadRequest();
            }
            try
            {         
                Comment c = new Comment()
                {
                    Id = Guid.NewGuid(),
                    Owner = ulogic.getUser(email),
                    Text = text,
                    Comments = new List<Comment>()
                };
                clogic.addSecondComment(GUID,c);
                return Ok();
            }
            catch(Exception e)
            {
                return InternalServerError(e);
            }            
        }
    }
}
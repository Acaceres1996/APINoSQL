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
    public class UserCommentController : ApiController
    {
        /*
            Crear Comentario
            POST api/UserComment/
            {
                "email":"u1@e.com"
            }
        */
        public async Task<IHttpActionResult> Post()
        {
            var rawMessage = await Request.Content.ReadAsStringAsync();
            dynamic entity = JObject.Parse(rawMessage);
            IBLComments clogic = BLFactory.GetBLComments();
            IBLUsers ulogic = BLFactory.GetBLUsers();
            if (null == entity["email"]) {
                return BadRequest("Campos erroneos");
            }                      
            try
            {
                string email = entity["email"];
                List<Comment> results = clogic.GetCommentsByEmail(email);
                return Ok(results);
            }
            catch(Exception e)
            {
                return InternalServerError(e);
            }            
        }    
    }
}
using System.Web.Http;
using Shared.Entities;
using System.Web.Http.Cors;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Factories;
using System;

namespace ApiServices.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ReadCommentController : ApiController
    {
        /*
            Leer Comentario
            POST api/ReadComment/
            {
		        "guid":"fc141a6d-9a66-4171-ac1a-e13eaeffbd6f"
            }
        */
        public async Task<IHttpActionResult> Post()
        {
            var rawMessage = await Request.Content.ReadAsStringAsync();
            dynamic entity = JObject.Parse(rawMessage);
            IBLComments clogic = BLFactory.GetBLComments();
            IBLUsers ulogic = BLFactory.GetBLUsers();
            if (null == entity["guid"])
            {
                return BadRequest();
            }                    
            try
            {
                string guid = entity["guid"];                  
                Comment c = clogic.GetCommentByGUID(guid);
                return Ok(c);
            }
            catch(Exception e)
            {
                return InternalServerError(e);
            }            
        }
    }
}
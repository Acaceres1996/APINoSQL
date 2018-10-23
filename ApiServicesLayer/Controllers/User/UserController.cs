using System.Web.Http;
using Shared.Entities;
using System.Web.Http.Cors;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.Factories;
using BusinessLogicLayer.Interfaces;
using System;

namespace ApiServices.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        /*
            Crear Usuario
            POST api/user
            {
		        "email": "u1@e.com"  
            }
        */
        public async Task<IHttpActionResult> Post()
        {
            var rawMessage = await Request.Content.ReadAsStringAsync();
            dynamic entity = JObject.Parse(rawMessage);
            IBLUsers logic = BLFactory.GetBLUsers();
            User u = new User();
            if (null == entity["email"])
            {
                return BadRequest("Campos erroneos");
            }
            try
            {
                u.Email = entity["email"];
                logic.AddUser(u);
                return Ok(u);
            }
            catch(Exception e)
            {
                return InternalServerError( e );
            }
        }
    }
}
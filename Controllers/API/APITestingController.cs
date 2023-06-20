using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Carnival.Controllers
{
    public class APITestingController : ApiController
    {
        [Route("api/apicontroller/{ID}")]
        public IHttpActionResult Get([FromUri]int ID)
        {
            if (ID<5)
            {
                return Ok(1);
            }
            else
            {
                return NotFound();
            }
        }
    }
}

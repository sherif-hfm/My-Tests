using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace JwtAuthServer.Controllers
{
    [RoutePrefix("api")]
    public class HomeController : ApiController
    {
        [Route("Hello")]
        [HttpGet]
        public Task<IHttpActionResult> Hello()
        {
            return Task.FromResult<IHttpActionResult>(Ok<string>("Welcome to Web Api"));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace JwtAuthServer.Controllers
{
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        [Route("GetData")]
        [HttpGet]
        [Authorize(Roles = "User")]
        public Task<IHttpActionResult> GetData()
        {
            return Task.FromResult<IHttpActionResult>(Ok<string>("Welcome to Users Web Api"));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiOwinSimple.Controllers
{
    [RoutePrefix("api")]
    public class HomeController : ApiController
    {
        [Route("Hello")]
        [HttpGet]
        public IHttpActionResult Hello()
        {
            return Content(System.Net.HttpStatusCode.OK, "Hello Web Api");
        }
    }
}

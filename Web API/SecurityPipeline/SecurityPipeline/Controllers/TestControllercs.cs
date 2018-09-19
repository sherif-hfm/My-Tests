using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net.Http;
using System.Security.Principal;

namespace SecurityPipeline.Controllers
{
    [RoutePrefix("api")]
    public class TestController : ApiController
    {
        [Route("test")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            //HttpContext.Current.Response.Write("OK");
            //return Ok();
            HttpContext.Current.GetOwinContext().Request.User = new GenericPrincipal(new GenericIdentity("dom"), new string[] { });
            return Content(System.Net.HttpStatusCode.OK, User.Identity.Name);
        }
    }
}
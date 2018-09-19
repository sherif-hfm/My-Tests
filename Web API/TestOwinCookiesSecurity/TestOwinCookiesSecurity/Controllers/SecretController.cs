using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Http;

namespace TestOwinCookiesSecurity.Controllers
{
    [RoutePrefix("api")]
    public class SecretController : ApiController
    {
        [Route("logout")]
        [HttpGet]
        public IHttpActionResult logout()
        {
            HttpContext.Current.GetOwinContext().Authentication.SignOut();
            return Content(System.Net.HttpStatusCode.OK, "Hello logout");
        }

        [Route("login")]
        [HttpGet]
        public IHttpActionResult login()
        {

            var identity = new ClaimsIdentity("ApplicationCookie");
            identity.AddClaims(new List<Claim>() { new Claim(ClaimTypes.NameIdentifier, "Sherif"), });

            //var user = new GenericPrincipal(new GenericIdentity("dom"), new string[] { });
            //HttpContext.Current.GetOwinContext().Authentication.User = user;
            HttpContext.Current.GetOwinContext().Authentication.SignIn(identity);
            return Content(System.Net.HttpStatusCode.OK, "Hello login");
        }

        [Route("index")]
        [HttpGet]
        public IHttpActionResult index()
        {
            return Content(System.Net.HttpStatusCode.OK, "Hello Index ") ;
        }

        [Authorize]
        [Route("data")]
        [HttpGet]
        public IHttpActionResult data()
        {
            return Content(System.Net.HttpStatusCode.OK, "Hello Secret Controller User: " + ((ClaimsPrincipal)User).Claims.First().Value);
        }
    }
}
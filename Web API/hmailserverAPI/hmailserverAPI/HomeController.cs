using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Caching;
using System.Web.Http;

namespace hmailserverAPI
{
    [RoutePrefix("api")]
    public class HomeController : ApiController
    {
        MemoryCache memCache = MemoryCache.Default;

        [Route("SetEmail")]
        [HttpGet]
        public IHttpActionResult SetEmail()
        {
            int counter = 0;
            var res = memCache.Get("EmailCounter");
            if (res == null)
            {
                memCache.Add("EmailCounter", 0, DateTimeOffset.UtcNow.AddHours(1));
            }
            else
            {
                counter = (int)res;
                memCache.Set("EmailCounter", ++counter, DateTimeOffset.UtcNow.AddHours(1));
            }

            return Content(System.Net.HttpStatusCode.OK, counter < 30 ? "true" : "false");
                //return Ok();
        }

        [Route("ClearEmail")]
        [HttpGet]
        public IHttpActionResult ClearEmail()
        {
           memCache.Remove("EmailCounter");
           return Ok();
        }
    }
}
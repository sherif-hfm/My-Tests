using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProtectedWebApi.Controllers
{
    public class ValuesController : ApiController
    {
        [HttpGet]
        [Authorize(Roles ="Admin")]
        public string Get()
        {
            return "OK " + User.Identity.Name;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CreatingMiddlewareWithOWIN.Controllers
{
    [RoutePrefix("api")]
    public class HelloWorldController : ApiController
    {
        [Route("hello")]
        [HttpGet]
        public IHttpActionResult HelloWorld()
        {
            return Content(System.Net.HttpStatusCode.OK, "Hello World WebAPI");
        }
    }
}
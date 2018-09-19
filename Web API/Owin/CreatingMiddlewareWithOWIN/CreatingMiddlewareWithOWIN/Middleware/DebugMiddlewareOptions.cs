using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreatingMiddlewareWithOWIN.Middleware
{
    public class DebugMiddlewareOptions
    {
        public Action<OwinContext> OnInRequest { get; set; }
        public Action<OwinContext> OnOutRequest { get; set; }
    }
}
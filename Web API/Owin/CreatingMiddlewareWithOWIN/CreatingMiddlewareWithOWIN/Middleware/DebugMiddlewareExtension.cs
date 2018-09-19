﻿using CreatingMiddlewareWithOWIN.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Owin
{
    public static class DebugMiddlewareExtension
    {
        public static void UseDebugMiddleware(this IAppBuilder app, DebugMiddlewareOptions options)
        {
            if (options == null)
                options = new DebugMiddlewareOptions();

            app.Use<DebugMiddleware>(options);
        }
    }
}
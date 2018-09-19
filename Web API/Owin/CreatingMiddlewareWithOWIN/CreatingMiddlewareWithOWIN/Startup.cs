using CreatingMiddlewareWithOWIN.Middleware;
using Owin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CreatingMiddlewareWithOWIN
{
    public class Startup
    {
        public static void Configuration(IAppBuilder app)
        {
            var Options = new DebugMiddlewareOptions();
            Options.OnInRequest = (ctx) => {
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                ctx.Environment["Stopwatch"] = stopwatch;
            };

            Options.OnOutRequest = (ctx) => {
                var stopwatch = (Stopwatch)ctx.Environment["Stopwatch"];
                stopwatch.Stop();
                Debug.WriteLine("Time :" + stopwatch.ElapsedMilliseconds.ToString());
            };

            //app.Use<DebugMiddleware>(Options);
            //app.UseDebugMiddleware(Options);

            app.UseCookieAuthentication(new Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions() { AuthenticationType = "ApplicationCookie" });

            // add web api
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            app.UseWebApi(config);

            app.Use(async(ctx, next) => {
                await ctx.Response.WriteAsync("Hello World");
                //await next();
            });
        }
    }
}
using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace OwinExample1
{
    public class Startup
    {
        public static void Configuration(IAppBuilder app)
        {
            app.Use(async (ctx, next) => {
                Debug.WriteLine("Request " + ctx.Request.Path.ToString());
                await next();
            });

            //app.Use(async (ctx, next) =>
            //{
            //    await ctx.Response.WriteAsync("Hello World1");
            //    //await next();
            //});
            app.Use(stage1);
        }

        public static async Task stage1(IOwinContext ctx, Func<Task> next)
        {
            await ctx.Response.WriteAsync("Hello World2");
            //await next();
        }
    }
}
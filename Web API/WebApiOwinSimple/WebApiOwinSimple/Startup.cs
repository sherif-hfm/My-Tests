using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebApiOwinSimple
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // add web api
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
        }
    }
}
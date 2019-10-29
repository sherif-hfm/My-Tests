using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace LocationApis
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // add web api
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                        name: "ResourceNotFound",
                        routeTemplate: "{*uri}",
                        defaults: new { controller = "Home", uri = RouteParameter.Optional });
            app.UseWebApi(config);
        }
    }
}
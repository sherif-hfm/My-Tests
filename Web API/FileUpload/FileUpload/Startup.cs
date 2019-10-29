using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace FileUpload
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // add web api
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            
            app.UseWebApi(config);
        }
    }
}
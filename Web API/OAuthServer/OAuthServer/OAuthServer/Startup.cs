using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.OAuth;
using System.Web.Http;
using System.Net.Http;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Owin.Security.DataProtection;
using System.Web.Security;

[assembly: OwinStartup(typeof(OAuthServer.Startup))]

namespace OAuthServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            // Do not forget to make machineKey in web.config the same in server and client

            /* PostMan Request
             POST /token HTTP/1.1
                Host: localhost:3212
                Content-Type: application/x-www-form-urlencoded
                Authorization: Basic YXNkOmFzZA==
                Cache-Control: no-cache
                Postman-Token: dd9626bb-80ec-4463-ab5a-1d6f36e1230a

                grant_type=password&username=asd&password=asd
             */

            
            app.SetDataProtectionProvider(new MachineKeyProtectionProvider()); // token generation Need when use sels host
            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions
            {
                // for demo purposes
                AllowInsecureHttp = true,

                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new SimpleAuthorizationServerProvider()
                //RefreshTokenProvider = new SimpleRefreshTokenProvider()
            });


            // use this for Secure the WebApi (remove this to separate the server and the Secure WebApi)
            // token consumption 
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());


            var config = new HttpConfiguration();
            // Web API routes
            config.MapHttpAttributeRoutes();
            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            app.UseWebApi(config);


        }
    }

    internal class MachineKeyProtectionProvider : IDataProtectionProvider
    {
        public IDataProtector Create(params string[] purposes)
        {
            return new MachineKeyDataProtector(purposes);
        }
    }

    internal class MachineKeyDataProtector : IDataProtector
    {
        private readonly string[] _purposes;

        public MachineKeyDataProtector(string[] purposes)
        {
            _purposes = purposes;
        }

        public byte[] Protect(byte[] userData)
        {
            return MachineKey.Protect(userData, _purposes);
        }

        public byte[] Unprotect(byte[] protectedData)
        {
            return MachineKey.Unprotect(protectedData, _purposes);
        }
    }
}

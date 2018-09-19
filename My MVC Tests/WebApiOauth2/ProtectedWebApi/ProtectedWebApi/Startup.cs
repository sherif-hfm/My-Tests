using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.OAuth;

[assembly: OwinStartup(typeof(ProtectedWebApi.Startup))]

namespace ProtectedWebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var OAuthOptions = new OAuthAuthorizationServerOptions
            {
                AuthorizeEndpointPath = PathString.FromUriComponent(new Uri("http://localhost:64928")),
                TokenEndpointPath = new PathString("/oauth/token"),
                AllowInsecureHttp = true
            };
            app.UseOAuthAuthorizationServer(OAuthOptions);
            app.UseOAuthBearerTokens(OAuthOptions);
        }
    }
}

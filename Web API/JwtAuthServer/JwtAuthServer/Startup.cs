using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security;
using Microsoft.IdentityModel.Tokens;

namespace JwtAuthServer
{
    public class Startup
    {
        private readonly string _appDomain = "https://eservices.alriyadh.gov.sa/";
        private readonly string _jwtSecret = "099153c2625149bc8ecb3e85e03f0022";

        public void Configuration(IAppBuilder app)
        {
            //https://cmikavac.net/2018/04/08/creating-and-consuming-jwt-tokens-in-net-webapi/
            //http://bitoftech.net/2014/10/27/json-web-token-asp-net-web-api-2-jwt-owin-authorization-server/
            // add web api
            ConfigureOAuth(app);
            ConfigureOAuthClient(app);

            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            
            //app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                //For Dev enviroment only (on production should be AllowInsecureHttp = false)
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
                Provider = new CustomOAuthProvider(),
                AccessTokenFormat = new CustomJwtFormat(_appDomain)
            };

            // OAuth 2.0 Bearer Access Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);

        }

        public void ConfigureOAuthClient(IAppBuilder app)
        {
            //var issuer = "https://eservices.alriyadh.gov.sa/";
            //var audience = "099153c2625149bc8ecb3e85e03f0022";
            //var secret = TextEncodings.Base64Url.Decode("IxrAjDoa2FqElO7IhrSrUJELhUckePEPVpaePlS_Xaw");

            // Api controllers with an [Authorize] attribute will be validated with JWT
            JwtBearerAuthenticationOptions JwtBearerAuthenticationOptions = new JwtBearerAuthenticationOptions
            {
                TokenValidationParameters = new TokenValidationParameters
                {
                    // The same _jwtSecret and _appDomain as in JwtTokenProvider were used here
                    IssuerSigningKey = _jwtSecret.ToSymmetricSecurityKey(),
                    ValidIssuer = _appDomain,
                    ValidAudience = _appDomain,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(0)
                }, 

            };
            app.UseJwtBearerAuthentication(JwtBearerAuthenticationOptions);

        }
    }
}
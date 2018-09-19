using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Collections.Generic;
using System.Security.Claims;

[assembly: OwinStartup(typeof(OneTimePassApi.Startup))]

namespace OneTimePassApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseBasicAuthentication("RmOtp", ValidateUsers);
            app.UseWebApi(WebApiConfig.Register());
        }

        private Task<IEnumerable<Claim>> ValidateUsers(string id, string secret)
        {
            if (id == "RmOtp" && secret == "dc7f3b22-42fe-4261-b09c-f581fbed1d3f")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, id),
                };

                return Task.FromResult<IEnumerable<Claim>>(claims);
            }

            return Task.FromResult<IEnumerable<Claim>>(null);
        }
    }
}

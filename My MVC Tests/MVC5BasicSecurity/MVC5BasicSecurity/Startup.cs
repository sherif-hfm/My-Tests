using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC5BasicSecurity.Startup))]
namespace MVC5BasicSecurity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

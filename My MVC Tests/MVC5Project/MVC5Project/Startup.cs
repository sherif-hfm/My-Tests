using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC5Project.Startup))]
namespace MVC5Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

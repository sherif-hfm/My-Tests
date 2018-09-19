using System.Web.Mvc;

namespace MVCExtending.Areas.BasicAuthenticationFilter
{
    public class BasicAuthenticationFilterAreaRegistration : AreaRegistration
    {
        public override string AreaName { get { return "BasicAuthenticationFilter"; } }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "BasicAuthenticationFilter_default",
                "BasicAuthenticationFilter/{action}/{id}",
                new { controller = "BasicAuthenticationFilter", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
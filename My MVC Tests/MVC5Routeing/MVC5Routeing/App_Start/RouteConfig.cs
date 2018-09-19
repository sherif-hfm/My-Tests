using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC5Routeing
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapMvcAttributeRoutes();

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");



             //The order of add MapRoute is important


            routes.MapRoute(name: "blog",
                            url: "code/{year}/{month}/{day}",
                            defaults: new { controller = "Section", action = "Report", year = @"\d{4}", month = @"\d{2}", day = @"\d{2}" }
                            );


            routes.MapRoute(
                     name: "Test",
                     url: "code2/{action}/{id}",
                     defaults: new { controller = "Section", action = "Index", id = "123" }
                     );
           

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            , namespaces: new[] { "MVC5Routeing.Controllers" }); // namespaces is mandatory to avoid  confilict between controllers with the same name in different areas

        }
    }
}

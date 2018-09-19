using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

/// <summary>
/// Summary description for RouteConfig
/// </summary>
public class RouteConfig
{
    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

        routes.MapRoute(
            "def",
            "{controller}/{action}/{id}",
            new { controller = "HomeController", action = "Index", id = UrlParameter.Optional },
            new[] { "" }
        );
       
    }
}
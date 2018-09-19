using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

/// <summary>
/// Summary description for WarehousesAreaRegistration
/// </summary>
public class WarehousesAreaRegistration : AreaRegistration
{
    public override string AreaName
    {
        get
        {
            return "TLS";
        }
    }

    public override void RegisterArea(AreaRegistrationContext context)
    {
        context.MapRoute(
            "tls_default",
            "tls/{controller}/{action}/{id}",
            new { controller = "home", action = "Index", id = UrlParameter.Optional },
            new[] { "Areas.TLS.Controllers" }
        );

        context.MapRoute(
            "bls_default",
            "bls/{controller}/{action}/{id}",
            new { controller = "home", action = "Index", id = UrlParameter.Optional },
            new[] { "Areas.BLS.Controllers" }
        );
       
    }
}
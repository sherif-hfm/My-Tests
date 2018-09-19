using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCApp
{
    public class Startup
    {
        public static void StartupMvc()
        {
            //ViewEngines.Engines.Clear();
            //ViewEngines.Engines.Add(new CustomViewEngine());

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
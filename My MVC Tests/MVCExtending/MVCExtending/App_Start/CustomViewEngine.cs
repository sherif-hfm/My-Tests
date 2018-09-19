using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace MVCExtending
{
    public class CustomViewEngine : RazorViewEngine
    {
        public override ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            ViewEngineResult result = base.FindView(controllerContext, viewName, masterName, useCache);
            if (result.View != null)
            {
                SetViewPath((RazorView)result.View, "http://localhost:61103/Views");
            }
            return result;
        }

        public override ViewEngineResult FindPartialView(ControllerContext controllerContext, string partialViewName, bool useCache)
        {
            ViewEngineResult result
                = base.FindPartialView(controllerContext, partialViewName, useCache);
            if (result.View != null)
            {
                SetViewPath((RazorView)result.View, "http://localhost:61103/Views");
            }
            return result;
        }

        static readonly PropertyInfo ViewPathProp = typeof(RazorView).GetProperty("ViewPath");

        public void SetViewPath(RazorView view, string path)
        {
            ViewPathProp.SetValue(view, path);
        }
    }
}
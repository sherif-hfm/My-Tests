using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace MVCExtending
{
    public class CustomActionMethodAttribute : ActionMethodSelectorAttribute
    {
        public override bool IsValidForRequest(ControllerContext controllerContext,MethodInfo methodInfo)
        {
            //return controllerContext.HttpContext.Request.IsAjaxRequest();
            return true;
        }
    }
}
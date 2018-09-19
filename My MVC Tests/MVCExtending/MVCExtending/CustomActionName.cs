using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace MVCExtending
{
    public class CustomActionNameAttribute : ActionNameSelectorAttribute
    {
        private string mActionName;
        public  CustomActionNameAttribute(string _actionName)
        {
            mActionName = _actionName;
        }
        public override bool IsValidName(ControllerContext controllerContext,string actionName,MethodInfo methodInfo)
        {
            return actionName == mActionName;
            //return true;
        }
    }
}
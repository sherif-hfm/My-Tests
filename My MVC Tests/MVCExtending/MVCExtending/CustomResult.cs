using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace MVCExtending
{
    public class CustomResult : ActionResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.ContentType = "application/json";
            var serializer = new JavaScriptSerializer();
            var serializedResult = serializer.Serialize("Data");
            context.HttpContext.Response.Write(serializedResult);
        }
    }
}
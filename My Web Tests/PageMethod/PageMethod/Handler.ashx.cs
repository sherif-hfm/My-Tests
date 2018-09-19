using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace PageMethod
{
    /// <summary>
    /// Summary description for Handler
    /// </summary>
    public class Handler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                var action = VirtualPathUtility.GetFileName(context.Request.Path);
                var methodInfo = this.GetType().GetMethod(action);
                object[] parameters = new object[1];
                parameters[0] = "asd";
                var response = methodInfo.Invoke(null, parameters).ToString();
                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                string jResponse = javaScriptSerializer.Serialize(response);
                context.Response.ContentType = "text/html";

                context.Response.Write(jResponse);
                context.Response.End();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public static string GetDate(string data)
        {
            return "Welcome to Page Method " + data + "  " + DateTime.Now.ToString();
        }
    }
}
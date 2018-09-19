using System;
using System.Web;
using System.Web.Script.Serialization;

namespace AspHttpHandler
{
    public class Handler1 : IHttpHandler
    {
        /// <summary>
        /// You will need to configure this handler in the Web.config file of your 
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpHandler Members

        public bool IsReusable
        {
            // Return false in case your Managed Handler cannot be reused for another request.
            // Usually this would be false in case you have some state information preserved per request.
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Clear();
            context.Response.ContentType = "text/plain";
            context.Response.Flush();
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            var json = javaScriptSerializer.Serialize(new { resultData = "OK" });
            context.Response.Write(json);
            context.Response.End();
            //HttpContext.Current.ApplicationInstance.CompleteRequest();
        }

        #endregion
    }
}

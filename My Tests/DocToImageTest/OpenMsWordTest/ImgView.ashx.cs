using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenMsWordTest
{
    /// <summary>
    /// Summary description for ImgView
    /// </summary>
    public class ImgView : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            var data = (byte[])context.Session["Data"];
            context.Response.ContentType = "Image/jpeg";
            context.Response.BinaryWrite(data);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
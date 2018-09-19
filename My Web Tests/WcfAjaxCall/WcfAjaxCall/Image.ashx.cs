using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
namespace WcfAjaxCall
{
    /// <summary>
    /// Summary description for Image
    /// </summary>
    public class Image : IHttpHandler
    {
        
        
        public void ProcessRequest(HttpContext context)
        {
            string imagepath = @"d:\qcode.jpg";
            byte[] imageData = File.ReadAllBytes(imagepath);
            context.Response.ContentType = "image/JPEG";
            context.Response.BinaryWrite(imageData);
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
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ImageReceiverTest
{
    /// <summary>
    /// Summary description for ImageReceiver
    /// </summary>
    public class ImageReceiver : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            
            Stream stream = context.Request.InputStream;
            byte[] data = new byte[stream.Length];
            stream.Read(data, 0, (int)stream.Length);
            File.WriteAllBytes(@"d:\result.jpg", data);
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
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
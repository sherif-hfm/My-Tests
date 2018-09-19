using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.SessionState;
namespace FineUploaderTest
{
    /// <summary>
    /// Summary description for Uploader
    /// </summary>
    public class Uploader : IHttpHandler, IReadOnlySessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            var fileId = context.Request["qquuid"];
            try
            {
                if(context.Request["Operation"]=="Add")
                {
                    AddFile(context);
                }

                if (context.Request["Operation"] == "Del")
                {
                    DeleteFile(context);
                }
            }
            catch (Exception ex)
            {
                context.Response.Clear();
                context.Response.ContentType = "text/plain";
                context.Response.Flush();
                var json = "{\"success\":false}";
                context.Response.Write(json);
                //context.Response.End(); 
            }
        }

        private void AddFile(HttpContext context)
        {
            if (context.Request.Files.Count > 0)
            {
                var fileId = context.Request["qquuid"];
                var file = context.Request.Files[0];
                var fileStream = file.InputStream;
                byte[] data = new byte[file.ContentLength];
                fileStream.Read(data, 0, file.ContentLength);
                SaveFile(data, file.FileName);
                context.Response.Clear();
                context.Response.ContentType = "text/plain";
                context.Response.Flush();
                var json = "{\"success\":true}";
                context.Response.Write(json);
                //context.Response.End();
            }
        }

        private void DeleteFile(HttpContext context)
        {
            var fileId = context.Request["qquuid"];
            var file = context.Request;
        }

        private void SaveFile(byte[] _data,string _fileName)
        {
            File.WriteAllBytes(@"d:\" + _fileName, _data);
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
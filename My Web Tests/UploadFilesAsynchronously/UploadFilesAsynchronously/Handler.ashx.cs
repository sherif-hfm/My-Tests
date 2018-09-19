using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;

namespace UploadFilesAsynchronously
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
                var fileName = context.Request.Headers["X_FILE_NAME"];
                var fullFileName = @"d:\" + fileName;
                var fileStream = context.Request.InputStream;
                byte[] data = new byte[context.Request.ContentLength];
                fileStream.Read(data, 0, (int)context.Request.ContentLength);
                while (!WriteFileData(fullFileName, data)) ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }

        private bool WriteFileData(string fileName, byte[] data)
        {
            try
            {
                using (var stream = new FileStream(fileName, FileMode.Append))
                {
                    stream.Write(data, 0, data.Length);
                    stream.Close();
                    //Thread.SpinWait(1000);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void ProcessRequest_smallFile(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            try
            {
                var file = context.Request.Files[0];
                var fileStream = file.InputStream;
                byte[] fileData = new byte[fileStream.Length];
                fileStream.Read(fileData, 0, (int)fileStream.Length);

                File.WriteAllBytes(@"d:\" + Path.GetFileName(file.FileName), fileData);
                HttpContext.Current.ApplicationInstance.CompleteRequest();
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
    }
}
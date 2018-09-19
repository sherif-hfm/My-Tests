using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.Script.Serialization;
namespace FineUploaderMulti
{
    /// <summary>
    /// Summary description for Uploader
    /// </summary>
    public class Uploader : IHttpHandler, IReadOnlySessionState
    {
        private List<UploadDocument> DocList;

        public void ProcessRequest(HttpContext context)
        {
            GetSession();
            try
            {
                if (context.Request["Operation"] == "Add")
                {
                    AddFile(context);
                }

                if (context.Request["Operation"] == "Del")
                {
                    DeleteFile(context);
                }
                RequestSuccess(context);
            }
            catch (Exception ex)
            {
                RequestFailed(context);

            }
        }

        private void AddFile(HttpContext context)
        {
            if (context.Request.Files.Count > 0)
            {
                var fileId = context.Request["qquuid"];
                var DocId = context.Request["DocId"];
                var file = context.Request.Files[0];
                var fileStream = file.InputStream;
                byte[] data = new byte[file.ContentLength];
                fileStream.Read(data, 0, file.ContentLength);
                if (DocList != null)
                {
                    var crDoc = DocList.Find(d => d.DocId == DocId);
                    if (crDoc.UploadFiles == null)
                        crDoc.UploadFiles = new List<UploadFile>();
                    UploadFile crFile = new UploadFile();
                    crFile.DocId = crDoc.DocId;
                    crFile.FileName = file.FileName;
                    crFile.FileSize = file.ContentLength;
                    crFile.FileId = fileId;
                    crDoc.UploadFiles.Add(crFile);
                    SaveSession();
                }
            }
        }

        private void DeleteFile(HttpContext context)
        {
            var fileId = context.Request["qquuid"];
            var DocId = context.Request["DocId"];
            if (DocList != null)
            {
                var crDoc = DocList.Find(d => d.DocId == DocId);
                if (crDoc.UploadFiles != null)
                {
                    var crFile = crDoc.UploadFiles.Find(f => f.FileId == fileId);
                    if (crFile != null)
                    {
                        crDoc.UploadFiles.Remove(crFile);
                    }
                }
            }
            SaveSession();
            RequestSuccess(context);
        }

        private void RequestSuccess(HttpContext context)
        {
            var fileId = context.Request["qquuid"];
            context.Response.Clear();
            context.Response.ContentType = "text/plain";
            context.Response.Flush();
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            var json = javaScriptSerializer.Serialize(new RequestResult() { success = "true", qquuid = fileId });
            context.Response.Write(json);
            //context.Response.End();
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }

        private void RequestFailed(HttpContext context)
        {
            context.Response.Clear();
            context.Response.ContentType = "text/plain";
            context.Response.Flush();
            var json = "{\"success\":false}";
            context.Response.Write(json);
            //context.Response.End();
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        private void GetSession()
        {
            DocList = (List<UploadDocument>)HttpContext.Current.Session["UploadDocList"];
        }

        private void SaveSession()
        {
            HttpContext.Current.Session["UploadDocList"] = DocList;
        }
    }
}

public class RequestResult
{
    public string success { get; set; }
    public string qquuid { get; set; }
}


public class FileSizeFormatProvider : IFormatProvider, ICustomFormatter
{
    public object GetFormat(Type formatType)
    {
        if (formatType == typeof(ICustomFormatter)) return this;
        return null;
    }

    private const string fileSizeFormat = "fs";
    private const Decimal OneKiloByte = 1024M;
    private const Decimal OneMegaByte = OneKiloByte * 1024M;
    private const Decimal OneGigaByte = OneMegaByte * 1024M;

    public string Format(string format, object arg, IFormatProvider formatProvider)
    {
        if (format == null || !format.StartsWith(fileSizeFormat))
        {
            return defaultFormat(format, arg, formatProvider);
        }

        if (arg is string)
        {
            return defaultFormat(format, arg, formatProvider);
        }

        Decimal size;

        try
        {
            size = Convert.ToDecimal(arg);
        }
        catch (InvalidCastException)
        {
            return defaultFormat(format, arg, formatProvider);
        }

        string suffix;
        if (size > OneGigaByte)
        {
            size /= OneGigaByte;
            suffix = "GB";
        }
        else if (size > OneMegaByte)
        {
            size /= OneMegaByte;
            suffix = "MB";
        }
        else if (size > OneKiloByte)
        {
            size /= OneKiloByte;
            suffix = "kB";
        }
        else
        {
            suffix = " B";
        }

        string precision = format.Substring(2);
        if (String.IsNullOrEmpty(precision)) precision = "2";
        return String.Format("{0:N" + precision + "}{1}", size, suffix);

    }

    private static string defaultFormat(string format, object arg, IFormatProvider formatProvider)
    {
        IFormattable formattableArg = arg as IFormattable;
        if (formattableArg != null)
        {
            return formattableArg.ToString(format, formatProvider);
        }
        return arg.ToString();
    }

}
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Web;

namespace PdfReport
{
    /// <summary>
    /// Summary description for PdfReport
    /// </summary>
    public class PdfReport : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string extension;
            string deviceInfo;
            Microsoft.Reporting.WebForms.ReportViewer rv1=new Microsoft.Reporting.WebForms.ReportViewer();

            rv1.ProcessingMode = ProcessingMode.Remote;
            rv1.ServerReport.ReportServerUrl = new Uri(@"http://10.110.137.27/reportserver");
            var reportId = context.Request.QueryString["ReportId"];
            //if (reportId == "1")
            var reportServerCredentials = new RmReportViewerCredentials();
            rv1.ServerReport.ReportServerCredentials = reportServerCredentials;
            rv1.ServerReport.ReportPath = @"/RM_Reports/Appointments/AppointmentTicket";
            //else
            //    rv1.ServerReport.ReportPath = @"/RM_Reports/Appointments/AppointmentTicket";

            try
            {
                rv1.ServerReport.SetParameters(new ReportParameter("pAppointment", "7da565e4-adbb-4a21-9788-712d5ca2fcf5"));
                byte[] bytes = rv1.ServerReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamids, out warnings);


                context.Response.ContentType = "application/pdf";
                context.Response.BinaryWrite(bytes);
            }
            catch (Exception ex)
            {

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

    [Serializable]
    public class RmReportViewerCredentials : IReportServerCredentials
    {
        #region IReportServerCredentials Members

        public bool GetFormsCredentials(out System.Net.Cookie authCookie, out string userName, out string password, out string authority)
        {
            authCookie = null;
            userName = "eservices";
            password = "P@ssw0rd";
            authority = "";

            return false;
        }

        public WindowsIdentity ImpersonationUser
        {
            get
            {
                WindowsIdentity result = WindowsIdentity.GetCurrent();
                return null;
            }
        }

        public System.Net.ICredentials NetworkCredentials
        {
            get
            {
                ICredentials result = new NetworkCredential("eservices", "P@ssw0rd", "itamana");
                return result;
            }
        }

        #endregion
    }
}
using Microsoft.Reporting.WebForms;
using ReportViewer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReportViewer.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ShowReport(ReportPrms prms)
        {
            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string extension;

            Microsoft.Reporting.WebForms.ReportViewer ReportViewer = new Microsoft.Reporting.WebForms.ReportViewer();
           
            //var reportServerCredentials = new ReportViewerCredentials();
            //ReportViewer.ServerReport.ReportServerCredentials = reportServerCredentials;
            ReportViewer.ProcessingMode = ProcessingMode.Remote;
            ReportViewer.ShowParameterPrompts = false;

            ReportViewer.ServerReport.ReportServerUrl = new Uri("http://132.35.6.50/reportserver");
            ReportViewer.ServerReport.ReportPath = "/RM_Reports/Appointments/OfficialAppointmentTicket";
            ReportViewer.ServerReport.SetParameters(new ReportParameter("pAppointment", "d0a36eff-7079-4da6-8215-820ed4d31ecf"));


            byte[] bytes = ReportViewer.ServerReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamids, out warnings);

            MemoryStream stream = new MemoryStream();
            stream.Write(bytes, 0, bytes.Length);
            stream.Position = 0;

            //FileStream fsSource = new FileStream(@"d:\day.pdf", FileMode.Open, FileAccess.Read);
            return File(stream, "application/pdf");
        }
    }
}
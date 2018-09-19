using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PdfReport
{
    public partial class ReportViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
                ViewReport();
        }

        private void ViewReport()
        {
            rv1.ProcessingMode = ProcessingMode.Remote;
            rv1.ServerReport.ReportServerUrl = new Uri(@"http://apps_dep_sherif/ReportServer");
            rv1.ServerReport.ReportPath = @"/Report1";
            //rv1.ServerReport.SetParameters(new ReportParameter("Prm1Value", "Hi Prm1"));
        }
    }
}
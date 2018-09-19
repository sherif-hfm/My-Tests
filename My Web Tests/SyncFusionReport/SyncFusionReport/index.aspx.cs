using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SyncFusionReport
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            rv1.ProcessingMode = Syncfusion.JavaScript.ReportViewerEnums.ProcessingMode.Remote;
            rv1.ReportServerUrl = "http://10.110.137.27/reportserver";
            rv1.ReportPath = @"/RM_Reports/Appointments/AppointmentTicket";
            List<string> values = new List<string>();
            values.Add("7da565e4-adbb-4a21-9788-712d5ca2fcf5");
            rv1.Parameters.Add(new Syncfusion.JavaScript.Models.ReportViewer.ReportParameter() { Name = "pAppointment", Values = values });
        }
    }
}
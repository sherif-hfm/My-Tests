using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UmAlQuraCalendarTest
{
    public partial class Index : System.Web.UI.Page
    {
        DateTime newdate;
        protected void Page_Load(object sender, EventArgs e)
        {
            var arCulInf = new CultureInfo("ar-SA");
            //var arCulInf = new CultureInfo("en-US");
            var hc = new HijriCalendar();// UmAlQuraCalendar();
            arCulInf.DateTimeFormat.Calendar = hc;
            Thread.CurrentThread.CurrentCulture = arCulInf;
            Thread.CurrentThread.CurrentUICulture = arCulInf;
            //newdate = DateTime.Parse("1436-02-30");
            //int year = hc.GetYear(DateTime.Now);
            //DateTime newdate2=hc.
            //Page.Title = newdate.ToString();
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            newdate = Calendar1.SelectedDate;
            int year = newdate.Year;
            Page.Title = newdate.ToString();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SearchPlans : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        string plan = Request.Form["NamecmbPlans"];
        string parcel = Request.Form["namecmbVersion"];
        Label1.Text = "   المخطط   " + plan + "   قطعة الارض     " + parcel;


    }
}
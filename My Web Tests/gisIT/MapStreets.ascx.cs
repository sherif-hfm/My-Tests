using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MAPS : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //   string day = Request.Form["n_daydropdown"];
        string NameMun = Request.Form["NamecmbMunc"];
        string NameDist = Request.Form["NamecmbDist"];
        string NameStreet = Request.Form["NameStreet"];
        string ss = HiddenField1.Value;
        Label1.Text = "   البلدية   " + NameMun + "   الحي     " + NameDist + "      الشارع          " + NameStreet;
    

    }
}
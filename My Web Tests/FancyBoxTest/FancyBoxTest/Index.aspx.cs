using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FancyBoxTest
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            lbl1.Text = DateTime.Now.ToString();
        }

        protected void btnShowWindow_Click(object sender, EventArgs e)
        {
            var script = "function f(){ShowWindow(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "ShowBillDetails", script, true);
        }

        
    }
}
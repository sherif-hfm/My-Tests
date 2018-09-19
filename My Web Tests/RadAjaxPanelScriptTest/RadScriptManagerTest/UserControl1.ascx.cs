using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RadScriptManagerTest
{
    public partial class UserControl1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "UserControl1", "alert('UserControl_Page_Load');", true);

            string script = @"function Startup()
    { alert('Startup');
        try {
            ShowUserControl1Alert();
        }
        catch (err) {
            // Handle error(s) here
        }
    }
    Sys.Application.remove_load(Startup);
    Sys.Application.add_load(Startup);";
            //if (this.Visible == true)
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "UserControl1", script, true);
        }

        protected void btnShowText_Click(object sender, EventArgs e)
        {
            txt.Visible = true;
        }

    }
}
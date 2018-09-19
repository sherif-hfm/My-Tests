using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TelerikWindow
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnShow_Click(object sender, EventArgs e)
        {

            //var script = "function f(){$find(\"" + win1.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "", script, true);
        }
    }
}
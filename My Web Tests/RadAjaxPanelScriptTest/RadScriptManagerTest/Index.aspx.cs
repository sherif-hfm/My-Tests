using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RadScriptManagerTest
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script src='My.js'></script>", false);
            //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "alert('Post')", true);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "", "<script type='text/javascript' src='My.js'></script>", false);
            //ScriptManager.RegisterClientScriptInclude(this, this.GetType(), "", "My.js");
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "", "ShowAlert();", true);

        }

        protected void btnViewText_Click(object sender, EventArgs e)
        {
            //txt1.Visible = true;
            UserControl1.Visible = true;
        }
    }
}
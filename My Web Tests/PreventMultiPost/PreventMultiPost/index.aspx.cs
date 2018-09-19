using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PreventMultiPost
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            msg.InnerHtml = "";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
           
            for (int i = 0; i < 10000000; i++)
            {
                msg.InnerHtml = "Save OK";
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServerControlTest
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CustomControl1_Click(object sender, EventArgs e)
        {
            CustomControl1.Text = "Ctrl1 " + DateTime.Now.ToLongTimeString();
        }

        

        
    }
}
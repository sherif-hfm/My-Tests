using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TextBoxClientSideValue
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //Note 
            // dislabled text do not submitted
            // read only text submit initial value
            var data = txtData.Text;
            txtData2.Text = txtData.Text;
        }
    }
}
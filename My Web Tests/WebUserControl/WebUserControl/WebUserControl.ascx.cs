using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebUserControl
{
    public partial class WebUserControl : System.Web.UI.UserControl, IPostBackEventHandler
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Event1 += WebUserControl_Event1;
            Button1.Click+=Button1_Click;
        }

        void WebUserControl_Event1(object sender, EventArgs e)
        {
            
        }

        public event EventHandler Event1;

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        public void RaisePostBackEvent(string eventArgument)
        {
            if(this.Event1!= null )
            {
                Event1(this, null);
            }

        }
    }
}
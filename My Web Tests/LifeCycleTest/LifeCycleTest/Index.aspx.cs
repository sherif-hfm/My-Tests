using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LifeCycleTest
{
    public partial class Index : System.Web.UI.Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.Load += Index_Load;
            var str = TextBox1.Text; 
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            var str = TextBox1.Text; 
        }

        void Index_Load(object sender, EventArgs e)
        {
            
        }
    }
}
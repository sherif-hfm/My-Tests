using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace jQueryTest
{
    public partial class Index : System.Web.UI.Page
    {

        protected override void OnPreInit(EventArgs e)
        {
            this.Load += Index_Load;
        }

        protected override void OnLoad(EventArgs e)
        {
            
        }

        void Index_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        
        
    }
}
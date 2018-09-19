using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ViewStateTest
{
    public partial class WebUserControl2 : System.Web.UI.UserControl
    {
        private string myVal = "asd2";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override object SaveViewState()
        {
            ViewState["myVal"] = myVal;
            return base.SaveViewState();
        }

        protected override void LoadViewState(object savedState)
        {
            base.LoadViewState(savedState);
            myVal = (string)ViewState["myVal"];

        }

        public string MyProperty { get; set; }
    }
}
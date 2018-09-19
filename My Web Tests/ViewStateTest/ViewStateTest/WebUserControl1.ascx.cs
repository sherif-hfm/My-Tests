using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ViewStateTest
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        private string myVal="asd1";
        protected void Page_Load(object sender, EventArgs e)
        {
            var asd = (WebUserControl2)this.Parent.FindControl("WebUserControl2");
        }

        protected override object SaveViewState()
        {
            var indexPage = ((Index)this.Page);
            ViewState["myVal"] = myVal;
            indexPage.PageViewState["myVal"] = myVal;
            //return base.SaveViewState();
            return indexPage.SavePageViewState();s
        }

        protected override void LoadViewState(object savedState)
        {
            base.LoadViewState(savedState);
            var indexPage = ((Index)this.Page);
            myVal = (string)indexPage.PageViewState["myVal"];
            myVal = (string)ViewState["myVal"];

        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ViewStateTest
{
    public partial class Index : System.Web.UI.Page
    {
        private string myVal = "asd";
        protected void Page_Load(object sender, EventArgs e)
        {
            //ViewState["myVal"] = myVal;  
            var asd = this.PageViewState;
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

        public StateBag PageViewState
        {
            get
            {
                return this.ViewState;
            }
        }

        public object SavePageViewState()
        {
            return base.SaveViewState();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PropertyBind
{
    public partial class index : System.Web.UI.Page
    {
        public string TestTXT { get; set; } = "KOKO";
        //public string TestTXT  = "KOKO";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Label1.DataBind();
            }
        }
        protected override object SaveViewState()
        {
            //ViewState["TestTXT"] = TestTXT;
            return base.SaveViewState();
        }

        protected override void LoadViewState(object savedState)
        {
            base.LoadViewState(savedState);
            //TestTXT = (string)ViewState["TestTXT"];
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.TestTXT = "KOKO2";
            Label1.DataBind();
        }
    }
}
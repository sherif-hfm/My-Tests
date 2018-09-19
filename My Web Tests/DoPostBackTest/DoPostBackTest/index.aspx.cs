using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoPostBackTest
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string eventArgs = Request["__EVENTARGUMENT"];
            if (eventArgs == "EventArgs")
                ToDoTask();
            hdn1.Value = Page.ClientScript.GetPostBackEventReference(btn1, "");
        }

        protected void btn1_Click(object sender, EventArgs e)
        {
            Page.Title = "OK";
        }

        private void ToDoTask()
        {

        }

        protected void hdnButton_Click(object sender, EventArgs e)
        {

        }
    }
}
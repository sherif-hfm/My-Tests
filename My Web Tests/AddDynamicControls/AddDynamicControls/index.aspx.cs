using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AddDynamicControls
{
    public partial class index : System.Web.UI.Page
    {
        public Dictionary<string,object> MyData { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                MyData = new Dictionary<string, object>();
            }
            SaveControlValues();
            CreateControls();
            
        }

        private void CreateControls()
        {
            TextBox txt1 = new TextBox() { ID = "txt1" };
            TextBox txt2 = new TextBox() { ID = "txt2" };
            if (MyData.ContainsKey("txt1"))
                txt1.Text = MyData["txt1"].ToString();
            if (MyData.ContainsKey("txt2"))
                txt2.Text = MyData["txt2"].ToString();
            ph1.Controls.Add(txt1);
            ph1.Controls.Add(txt2);
        }

        private void SaveControlValues()
        {
            foreach(var key in  this.Request.Form.AllKeys)
            {
                MyData[key] = this.Request.Form[key];
            }
        }

        #region *********************** State Management ***********************
        protected override object SaveViewState()
        {

            ViewState["MyData"] = MyData;

            return base.SaveViewState();
        }

        protected override void LoadViewState(object savedState)
        {
            base.LoadViewState(savedState);
            MyData = (Dictionary<string, object>)ViewState["MyData"];
        }

        #endregion
    }
}
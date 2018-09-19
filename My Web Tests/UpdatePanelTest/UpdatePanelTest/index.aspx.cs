using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UpdatePanelTest
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadGrd1Data();
                LoadGrd2Data();
            }
        }

        private void LoadGrd1Data()
        {
            var items = new List<Items>();
            items.Add(new Items() { ItemCode = "1", ItemName = "Item1" });
            items.Add(new Items() { ItemCode = "2", ItemName = "Item2" });
            items.Add(new Items() { ItemCode = "3", ItemName = "Item3" });
            grd1.DataSource = items;
            grd1.DataBind();
        }

        private void LoadGrd2Data()
        {
            var items = new List<Items>();
            items.Add(new Items() { ItemCode = "1", ItemName = "Item1" });
            items.Add(new Items() { ItemCode = "2", ItemName = "Item2" });
            items.Add(new Items() { ItemCode = "3", ItemName = "Item3" });
            grd2.DataSource = items;
            grd2.DataBind();
        }

        protected void btn1_Click(object sender, EventArgs e)
        {
            Thread.Sleep(new TimeSpan(0, 0, 5));
            txtMain1.Text = "Reload";
            txt1.Text = "Reload";
        }

        protected void btn2_Click(object sender, EventArgs e)
        {
            Thread.Sleep(new TimeSpan(0, 0, 5));
        }
    }

    class Items
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
    }
}
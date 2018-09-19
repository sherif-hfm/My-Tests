using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace TelerikRadGrid
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            List<Person> data = new List<Person>();
            data.Add(new Person() { PersonId = 1, PersonName = "a", PersonAddress = "aa" });
            data.Add(new Person() { PersonId = 2, PersonName = "b", PersonAddress = "bb" });
            data.Add(new Person() { PersonId = 3, PersonName = "c", PersonAddress = "cc" });
            data.Add(new Person() { PersonId = 4, PersonName = "d", PersonAddress = "dd" });

            grd.DataSource = data;
            grd.DataBind();
        }

        protected void grd_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if(e.CommandName=="Cmd1")
            {
                var index = Convert.ToInt32(e.CommandArgument);
                var personId1 = (int)(e.Item as GridDataItem).OwnerTableView.DataKeyValues[e.Item.ItemIndex]["PersonId"];
                var personId = (int)(e.Item as GridDataItem).OwnerTableView.DataKeyValues[index]["PersonId"];
            }
            
        }
    }

    public class Person
    {
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public string PersonAddress { get; set; }
    }
}
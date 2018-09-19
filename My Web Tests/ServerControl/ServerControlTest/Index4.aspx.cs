using ServerControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServerControlTest
{
    public partial class Index4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var data= new List<Person>();
            data.Add(new Person() { Name = "Sherif" });
            data.Add(new Person() { Name = "Ahmed" });
            data.Add(new Person() { Name = "Mohamed" });
            ctrl1.DataSource = data;
            ctrl1.DataBind();
        }
    }
}
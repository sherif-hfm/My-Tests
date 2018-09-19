using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ServiceReference1.Service1Client cnn = new ServiceReference1.Service1Client();
        var asd = cnn.GetData(5);
        this.Title = asd;
    }
}
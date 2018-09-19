using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WcfSrv;

namespace WcfCallTest
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Session["UserId"] = "12345";
            var srv = WcfServices.GetWsService<IService1>();
            var result = srv.GetData();
        }
    }
}
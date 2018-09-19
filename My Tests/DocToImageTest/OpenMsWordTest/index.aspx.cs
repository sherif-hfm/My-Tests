using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OpenMsWordTest
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnViewImage_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "ok";
            byte[] data = File.ReadAllBytes(@"D:\DocFlowFiles\session.jpg");
            Session["Data"] = data;
            imgDoc.ImageUrl = "ImgView.ashx?id=" + Guid.NewGuid().ToString();
        }
    }
}
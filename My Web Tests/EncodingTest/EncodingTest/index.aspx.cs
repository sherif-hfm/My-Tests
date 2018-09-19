using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EncodingTest
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ustr1 = "\ud9a3";
            string ustr2 = "\u03a0";
            string ustr3 = string.Format(@"\u{0:x4}", 3);
            string str1 = "٣٠";
            string str2 = "٣";
            string str3 = "3";
            string str4 = "أ";
            var codes1 = Encoding.UTF8.GetBytes(str2);
            var codes2 = Encoding.UTF8.GetBytes(str4);
            var codes3 = Encoding.UTF8.GetBytes(ustr1);
            //byte[] codes3 = Encoding.Convert(Encoding.UTF8, Encoding.ASCII, codes2);
            string msg = Encoding.UTF8.GetString(codes1);
        }
    }
}
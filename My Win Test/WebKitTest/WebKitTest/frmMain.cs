using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebKitTest
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            webKitBrowser1.Url = new Uri(@"http://localhost:31365/HtmlPage.html");
        }
    }
}

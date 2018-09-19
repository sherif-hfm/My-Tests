using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HtmlRendererTest
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            TheArtOfDev.HtmlRenderer.WinForms.HtmlPanel htmlPanel = new TheArtOfDev.HtmlRenderer.WinForms.HtmlPanel();
            //htmlPanel.Text = "<p><h1>Hello World</h1>This is html rendered text</p>";
            htmlPanel.Text = Resource1.Html;
            htmlPanel.Dock = DockStyle.Fill;
            Controls.Add(htmlPanel);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketTest
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Thread thread1 = new Thread(ShowServer);
            Thread thread2 = new Thread(ShowClient);
            thread2.Start();
            thread1.Start();
            this.Hide();
        }

        private void ShowServer()
        {
            var server = new frmServer();
            server.ShowDialog();
        }

        private void ShowClient()
        {
            var client = new frmClient();
            client.ShowDialog();
        }
    }
}

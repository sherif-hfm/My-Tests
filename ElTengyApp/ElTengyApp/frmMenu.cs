using ElTengyApp.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElTengyApp
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void BtnAddStudent_Click(object sender, EventArgs e)
        {
            var frm = new frmSaveData();
            frm.ShowDialog();
        }

        private void btnGetStudent_Click(object sender, EventArgs e)
        {
            var frm = new frmGetData();
            frm.ShowDialog();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace FileWatcher
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            FileSystemWatcher fsw2 = new FileSystemWatcher() { Path = @"D:\DocFlowFiles" };
            {
                fsw2.Filter = "*test1.docx";
                fsw2.Renamed += Fsw_Renamed;
                //fsw2.Error += Fsw_Error;
                fsw2.Deleted += Fsw_Deleted;
                //fsw2.Changed += Fsw_Changed;
                //fsw2.Created += Fsw_Created;
                fsw2.EnableRaisingEvents = true;
            }
        }

        private void Fsw_Renamed(object sender, RenamedEventArgs e)
        {
            
        }

        private void Fsw_Created(object sender, FileSystemEventArgs e)
        {

        }

        private void Fsw_Changed(object sender, FileSystemEventArgs e)
        {

        }

        private void Fsw_Deleted(object sender, FileSystemEventArgs e)
        {

        }

        private void Fsw_Error(object sender, ErrorEventArgs e)
        {

        }
    }
}

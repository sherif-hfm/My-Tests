using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilesDistributor
{
    public partial class frmMain : Form
    {
        public string SourcePath { get; set; }

        public string DestinationPath { get; set; }

        public string FileFilter { get; set; }

        public bool AutoStart { get; set; }

        public bool NeedStop { get; set; }

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ReadSettings();
            if (this.AutoStart == true)
            {
                this.NeedStop = false;
                bgWorker.RunWorkerAsync();
            }
        }

        private void ReadSettings()
        {
            this.SourcePath= ConfigurationManager.AppSettings["SourcePath"];
            txtSource.Text = this.SourcePath;

            this.DestinationPath = ConfigurationManager.AppSettings["DestinationPath"];
            txtDestination.Text = this.DestinationPath;

            this.FileFilter = ConfigurationManager.AppSettings["FileFilter"];
            txtFileFilter.Text = this.FileFilter;

            this.AutoStart = bool.Parse(ConfigurationManager.AppSettings["AutoStart"]);
        }

        private void StartDistribute()
        {
            var files = Directory.GetFiles(this.SourcePath, this.FileFilter);
            int index = 0;
            foreach(var fileStr in files)
            {
                if(this.NeedStop == false)
                {
                    FileInfo fileInfo = new FileInfo(fileStr);
                    var desDir = this.DestinationPath + fileInfo.LastWriteTime.Year.ToString("000") + "\\" + fileInfo.LastWriteTime.ToString("yyyy-MM-dd");
                    var desFile = desDir + "\\" + fileInfo.Name;
                    if (Directory.Exists(desDir) == false)
                    {
                        Directory.CreateDirectory(desDir);
                    }
                    //File.Copy(fileStr, desFile, true);
                    File.Move(fileStr, desFile);
                    index++;
                    UpdateProgressBar(files.Length, index);
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            this.NeedStop = false;
            bgWorker.RunWorkerAsync();
        }

        private void UpdateProgressBar(int _max ,int _value)
        {
            if (this.progressBar.InvokeRequired)
            {
                this.Invoke(new Action(() => { UpdateProgressBar(_max, _value); }));
            }
            else
            {
                progressBar.Maximum = _max;
                progressBar.Value = _value;
            }
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            StartDistribute();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.NeedStop = true;
        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(this.AutoStart==true)
            {
                Application.Exit();
            }
        }
    }
}

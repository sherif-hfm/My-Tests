using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenMsWord
{
    public partial class frmMain : Form
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll")]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, ExactSpelling = true, SetLastError = true)]
        internal static extern void MoveWindow(IntPtr hwnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        public static int GWL_STYLE = -16;
        public static int WS_CHILD = 0x40000000;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Click(object sender, EventArgs e)
        {
            
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var process = new Process();
            process.StartInfo.FileName = @"winword.exe";
            process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            process.Start();
            process.WaitForInputIdle();
            Task task = new Task(new Action(() => {
                process.WaitForExit();
                this.Text = "OK";
            }));
            task.Start();
            //IntPtr guestHandle = process.MainWindowHandle;
            //SetWindowLong(guestHandle, GWL_STYLE, GetWindowLong(guestHandle, GWL_STYLE) | WS_CHILD);
            Thread.Sleep(2000);
            //SetParent(process.MainWindowHandle, this.Handle);
            MoveWindow(process.MainWindowHandle, 0, 0, 300, 500, true);
        }
    }
}

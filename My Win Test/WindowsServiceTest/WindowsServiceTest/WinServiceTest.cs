using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsServiceTest
{
    partial class WinServiceTest : ServiceBase
    {
        private System.Timers.Timer timer;
        MyWork work;
        public WinServiceTest()
        {
            InitializeComponent();
            timer = new System.Timers.Timer(1000);
            timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            EventLog.WriteEntry("Timer Start");
            timer.Stop();
            work = new MyWork();
            work.DoSomething();
            timer.Interval = 1000;
            timer.Start();
        }

        protected override void OnStart(string[] args)
        {
            timer.Interval = 1000;
            timer.Start();
            EventLog.WriteEntry("WinServiceTest Start");
            // TODO: Add code here to start your service.
        }

        protected override void OnStop()
        {
            EventLog.WriteEntry("WinServiceTest Try to Stop");
            work.Stop();
            EventLog.WriteEntry("WinServiceTest Stoped");
        }
    }
}

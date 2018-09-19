using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsServiceTest
{
    public class MyWork
    {
        private bool needStop;
        private bool workEnded;
        public void DoSomething()
        {
            needStop = false;
            workEnded = false;
            File.AppendAllLines(@"d:\WinSrv.txt", new string[1] { "****************** Work Start ******************" });
            for (int index = 0; index < 10; index++)
            {
                if (needStop == true)
                    break;
                    File.AppendAllLines(@"d:\WinSrv.txt", new string[1] { "index = " + index + " " + DateTime.Now.ToString() });
                    Thread.Sleep(new TimeSpan(0, 0, 5));
            }
            File.AppendAllLines(@"d:\WinSrv.txt", new string[1] { "****************** Work Ended ******************" });
            workEnded = true;
        }

        public void Stop()
        {
            needStop = true;
            while (!workEnded) ;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TimerTest
{
    class Program
    {
        private static System.Timers.Timer myTimer;
        static void Main(string[] args)
        {
            myTimer = new System.Timers.Timer();
            myTimer.Elapsed += MyTimer_Elapsed;
            myTimer.Interval = 3000;
            myTimer.Enabled = true;
            Console.ReadLine();
        }

        private static void MyTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            myTimer.Enabled = false;
            Console.WriteLine("Elapsed " + DateTime.Now.ToString());
            Thread.Sleep(1000);
            myTimer.Interval = 5000;
            myTimer.Enabled = true;
        }
    }
}

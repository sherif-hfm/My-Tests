using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DateTimeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var start = DateTime.Now.Ticks;
            var end = DateTime.Now.Add(new TimeSpan(0, 0, 5)).Ticks;
            while (true)
            {
                var now = DateTime.Now.Ticks;
                var span = new TimeSpan(0, 0, 10).Ticks;
                Console.WriteLine((end- now).ToString() + " - " + DateTime.Now.ToString());
                Thread.Sleep(100);
            }
        }
    }
}

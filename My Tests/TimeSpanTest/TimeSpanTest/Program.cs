using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSpanTest
{
    class Program
    {
        static void Main(string[] args)
        {
            TimeSpan TimeSpan1 = new TimeSpan(10, 0, 0);
            TimeSpan TimeSpan2 = new TimeSpan(10, 0, 1);

            DateTime Time1 = new DateTime(1, 1, 1, 1, 2, 0);
            DateTime Time2 = new DateTime(1, 1, 1, 1, 1, 0);
            if (Time2 > Time1)
            {
                Console.WriteLine("OK");
            }
            Console.ReadLine();
        }
    }
}

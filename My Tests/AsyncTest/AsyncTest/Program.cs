using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncTest
{
    class Program
    {
        static void Main(string[] args)
        {
           DoNumbers();
           DoOks();
           
           Console.ReadLine();
        }

        async static void DoNumbers()
        {
            int x = 1;
            //await Task.Run(() => PrintNumbers(x));
            PrintNumbers();
            DoOks2();
            Task.Run(() => PrintNumbers2(x));
        }

        static void DoOks()
        {
            Console.WriteLine("********** OK A **********");
            Console.WriteLine("********** OK B **********");
            Console.WriteLine("********** OK C **********");
        }

        static void DoOks2()
        {
            Console.WriteLine("********** OK D **********");
            Console.WriteLine("********** OK E **********");
            Console.WriteLine("********** OK F **********");
        }

        async static Task<int> PrintNumbers()
        {
            await Task.Delay(2000);
            for (int i = 0; i < 100; i++)
                Console.WriteLine(i.ToString());
            return 0;
        }
        static void PrintNumbers2(int x)
        {

            for (int i = 100; i < 200; i++)
                Console.WriteLine(i.ToString());
        }


    }
}

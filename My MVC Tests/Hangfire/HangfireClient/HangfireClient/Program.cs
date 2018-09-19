using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangfireClient
{
    class Program
    {
        static void Main(string[] args)
        {
            GlobalConfiguration.Configuration.UseSqlServerStorage("DefaultConnection");
            BackgroundJob.Enqueue(() => DoJob());
            Console.ReadLine();
        }

        public static void DoJob()
        {
            Console.WriteLine("Welcome to Hangfire");
        }
    }
}

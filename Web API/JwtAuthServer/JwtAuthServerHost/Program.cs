using JwtAuthServer;
using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtAuthServerHost
{
    class Program
    {
        static void Main(string[] args)
        {
            /* http://localhost:9001/api/Hello */
            string baseAddress = "http://*:9001";

            // Start OWIN host 
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                Console.ReadLine();
            }
        }
    }
}

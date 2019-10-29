using FileUpload;
using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUploadHost
{
    class Program
    {
        static void Main(string[] args)
        {
            //netsh http add sslcert ipport=0.0.0.0:443 certhash=‎1d1218c84627da53cecf55f90a997b8556e03da1 appid={dba32a70-65f3-41e4-8920-cbe2d9925ed9}
            string baseAddress = "http://*:9001/";

            // Start OWIN host 
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                Console.ReadLine();
            }
        }
    }
}

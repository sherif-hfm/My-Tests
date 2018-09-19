using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWcfService
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceWCF.Service1Client srv = new ServiceWCF.Service1Client();
            var result= srv.GetData("1");
        }
    }
}

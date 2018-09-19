using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Routing;
using System.Text;
using System.Threading.Tasks;

namespace WCFRoutingHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new ServiceHost(typeof(RoutingService));
            host.Open();
            Console.WriteLine("Server is running.");
            Console.ReadLine();
            host.Close();
        }
    }
}

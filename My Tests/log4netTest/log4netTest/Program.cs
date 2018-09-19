using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using System.Reflection;
namespace log4netTest
{
    class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            XmlConfigurator.Configure();

            Log.Debug("Application Start");

            Console.WriteLine("Application");

            Log.Debug("Application End");

            Console.ReadLine();

        }
    }
}

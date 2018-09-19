using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace JSONDateTimeSerializ
{
    class Program
    {
        static void Main(string[] args)
        {
            Serialize1();
            Serialize2();
        }

        private static void Serialize1()
        {
            DateTime myDate = new DateTime(2016, 6, 1, 10, 0, 0);
            JavaScriptSerializer ser = new JavaScriptSerializer();
            string json = ser.Serialize(myDate);
            DateTime myDate2 = ser.Deserialize<DateTime>(json);
        }

        private static void Serialize2()
        {
            DateTime myDate = new DateTime(2016, 6, 1, 10, 0, 0);
            string json = JsonConvert.SerializeObject(myDate);
            DateTime myDate2 = JsonConvert.DeserializeObject<DateTime>(json);
        }
    }
}

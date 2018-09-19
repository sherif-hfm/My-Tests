using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace S9TemperatureMonitoring
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpWebRequest http = (HttpWebRequest)WebRequest.Create("http://www.sherif.online:1014/cgi-bin/minerStatus.cgi");
            string headerValue = Resource.ResourceManager.GetString("Authorization");
            http.Headers.Add("Authorization", headerValue);
            WebResponse response = http.GetResponse();
            var stream = response.GetResponseStream(); 
            StreamReader sr = new StreamReader(stream);
            string content = sr.ReadToEnd();

            MatchCollection matchs = Regex.Matches(content, Resource.ResourceManager.GetString("Reg"));
            foreach(Match item in matchs)
            {
                var value = item.Groups[1].Value;
            }
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebClientTest
{
    class Program
    {
        static void Main(string[] args)
        {
            WebClient client = new WebClient();
            string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes("5085569adf1b446aba575bb373598635"));
            client.Headers[HttpRequestHeader.Authorization] = string.Format("Basic {0}", credentials);
            //using (Stream stream = client.OpenRead("https://www.streak.com/api/v1/pipelines/agxzfm1haWxmb29nYWVyPQsSDE9yZ2FuaXphdGlvbiIWZS5hYmR1bG1hbGVrQGdtYWlsLmNvbQwLEghXb3JrZmxvdxiAgICA0IyICgw/boxes"))
            using (Stream stream = client.OpenRead("https://www.streak.com/api/v1/pipelines"))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    bool canRead = true;
                    while (canRead)
                    {
                        byte[] data = new byte[1024];
                        var count=stream.Read(data, 0, 1024);
                        if (count > 0)
                            ms.Write(data, 0, count);
                        else
                            canRead = false;
                    }
                    var dataStr = System.Text.Encoding.UTF8.GetString(ms.ToArray());
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Getpipelines();
            //GetBoxs();
            GetBox();
        }

        private static void Getpipelines()
        {
            using (var client = new HttpClient(new HttpClientHandler() { }))
            {
                client.BaseAddress = new Uri("https://www.streak.com");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + Convert.ToBase64String(new ASCIIEncoding().GetBytes("156ce00a80624313b9fb2c96da68e2b6")));
                HttpResponseMessage response = client.GetAsync("/api/v1/pipelines").Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    dynamic serviceData = new ExpandoObject();
                    //serviceData = response.Content.ReadAsStringAsync();
                    serviceData = response.Content.ReadAsAsync<List<ExpandoObject>>();
                }
            }
        }

        private static void GetBoxs()
        {
            using (var client = new HttpClient(new HttpClientHandler() { }))
            {
                client.BaseAddress = new Uri("https://www.streak.com");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + Convert.ToBase64String(new ASCIIEncoding().GetBytes("156ce00a80624313b9fb2c96da68e2b6")));
                var pipeline = "agxzfm1haWxmb29nYWVyOwsSDE9yZ2FuaXphdGlvbiIUc2hlcmlmLmhmbUBnbWFpbC5jb20MCxIIV29ya2Zsb3cYgICAgIDkkQoM";
                string action = string.Format("/api/v1/pipelines/{0}/boxes", pipeline);
                HttpResponseMessage response = client.GetAsync(action).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    dynamic serviceData = new ExpandoObject();
                    //serviceData = response.Content.ReadAsStringAsync();
                    serviceData = response.Content.ReadAsAsync<List<ExpandoObject>>();
                }
            }
        }

        private static void GetBox()
        {
            using (var client = new HttpClient(new HttpClientHandler() { }))
            {
                client.BaseAddress = new Uri("https://www.streak.com");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + Convert.ToBase64String(new ASCIIEncoding().GetBytes("156ce00a80624313b9fb2c96da68e2b6")));
                var boxKey = "agxzfm1haWxmb29nYWVyMgsSDE9yZ2FuaXphdGlvbiIUc2hlcmlmLmhmbUBnbWFpbC5jb20MCxIEQ2FzZRix6gEM";
                string action = string.Format("/api/v1/boxes/{0}", boxKey);
                HttpResponseMessage response = client.GetAsync(action).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    dynamic serviceData = new ExpandoObject();
                    //serviceData = response.Content.ReadAsStringAsync();
                    serviceData = response.Content.ReadAsAsync<ExpandoObject>();
                }
            }
        }


    }
}

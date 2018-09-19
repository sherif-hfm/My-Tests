using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceHttpRequest
{
    class Program
    {
        static void Main(string[] args)
        {
            var request = (HttpWebRequest)WebRequest.Create("http://eservice-test-mw.itamana.net:5000/Common/Common.svc/basic");

            var postData = @"<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:tem='http://tempuri.org/'>
   <soapenv:Header/>
   <soapenv:Body>
      <tem:GenerateQRCode>
         <!--Optional:-->
         <tem:idKey>1</tem:idKey>
         <!--Optional:-->
         <tem:idKey2>1</tem:idKey2>
         <!--Optional:-->
         <tem:qrContent>شريف</tem:qrContent>
         <!--Optional:-->
         <tem:qrDesc>شريف</tem:qrDesc>
      </tem:GenerateQRCode>
   </soapenv:Body>
</soapenv:Envelope>";
            var data = Encoding.ASCII.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = "text/xml;charset=UTF-8";
            //request.Headers.Add("Accept-Encoding", "gzip,deflate");
            request.Headers.Add("SOAPAction", "\"http://tempuri.org/ICommon/GenerateQRCode\"");
            //request.Headers.Add("Connection", "Keep-Alive");
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();


            string Charset = response.CharacterSet;
            Encoding encoding = Encoding.GetEncoding(Charset);

            var Stream = new StreamReader(response.GetResponseStream(), encoding);
            var result = Stream.ReadToEnd();
        }
    }
}

using System;
using System.Configuration;
using System.Web;
using System.Net;
using System.Text;
using System.IO;
using System.Web.SessionState;

namespace ReverseProxyTest
{
    public class RmReverseProxy : IHttpHandler, IRequiresSessionState
    {
        /// <summary>
        /// Method calls when client request the server
        /// </summary>
        /// &;lt;param name="context">HTTP context for client</param>

        public void ProcessRequest(HttpContext context)
        {
            if(context.Session["Users"] == null)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                context.Response.StatusDescription = HttpStatusCode.Unauthorized.ToString();
                context.Response.End();
                return;
            }
         
           
            string remoteWebSite = "http://10.120.34.23:5001";
            string remoteUrl = remoteWebSite + context.Request.Path.Replace(@"/SecPages", ""); 
            
            int tries = 0;
            while (tries < 10 )
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(remoteUrl);
                try
                {
                    request.Timeout = 5000;
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {

                        var receiveStream = response.GetResponseStream();
                        tries = 11;
                        if ((response.ContentType.ToLower().IndexOf("html") >= 0))
                        {
                            string jwtToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c";
                            //this response is HTML Content, so we must parse it
                            StreamReader readStream = new StreamReader(receiveStream, Encoding.Default);
                            string content = ParseHtmlResponse(readStream.ReadToEnd(),
                              context.Request.ApplicationPath);
                            //write the updated HTML to the client
                            context.Response.Headers.Add("Authorization", "Bearer " + jwtToken);
                            context.Response.ContentType = response.ContentType;
                            context.Response.Write(content);
                            response.Close();
                            context.Response.End();
                        }
                        else if ((response.ContentType.ToLower().IndexOf("java") >= 0)) {
                            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                            string content = readStream.ReadToEnd();
                            //Write the stream directly to the client
                            var content2 = ParseJsResponse(content);
                            var buff = Encoding.UTF8.GetBytes(content2);
                                context.Response.OutputStream.Write(buff, 0, buff.Length);
                            
                            context.Response.ContentType = response.ContentType;
                            //close streams
                            response.Close();
                            context.Response.End();
                        }
                        else
                        {
                            //the response is not HTML 
                            byte[] buff = new byte[1024];
                            int bytes = 0;
                            while ((bytes = receiveStream.Read(buff, 0, 1024)) > 0)
                            {
                                //Write the stream directly to the client 
                                context.Response.OutputStream.Write(buff, 0, bytes);
                            }
                            context.Response.ContentType = response.ContentType;
                            //close streams
                            response.Close();
                            context.Response.End();
                        }
                        return;
                    }
                }
                catch (System.Net.WebException we)
                {
                    tries++;
                } 
            }
            context.Response.StatusCode = 404;
            context.Response.StatusDescription = "Not Found";
            context.Response.Write("<h2>Page not found</h2>");
            context.Response.End();

        }
      
        public string ParseHtmlResponse(string html, string appPath)
        {
            html = html.Replace("\"/", "\"" + appPath + "SecPages/");
            html = html.Replace("'/", "'" + appPath + "SecPages/");
            html = html.Replace("=/", "=" + appPath + "SecPages/");
            return html;
        }

        public string ParseJsResponse(string js)
        {
            string result = js.Replace("/assets/img/", "/SecPages/assets/img/");
         
            return result;
        }
      
        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
    }
}
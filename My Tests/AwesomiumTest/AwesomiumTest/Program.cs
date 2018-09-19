using Awesomium.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AwesomiumTest
{
    class Program
    {
        
        static void Main(string[] args)
        {
            WebCore.Initialize(new WebConfig(), true);
            using (WebView browser = WebCore.CreateWebView(793, 1122, WebViewType.Offscreen))
            {
                browser.DocumentReady += browser_DocumentReady;
                browser.LoadingFrameComplete += Browser_LoadingFrameComplete;
                //browser.Source = new Uri("http://localhost:31365/HtmlPage.html");
                browser.LoadHTML(Resource.html);
                WebCore.Run();
            }
            Console.ReadLine();
        }

        private static void Browser_LoadingFrameComplete(object sender, FrameEventArgs e)
        {
            using (var webView = (WebView)sender)
            {
                BitmapSurface surface = (BitmapSurface)webView.Surface;
                surface.SaveToJPEG(@"d:\result.jpg");
                var data =File.ReadAllBytes(@"d:\result.jpg");
                Console.WriteLine("DocumentReady");
            };
        }

        static void browser_DocumentReady(object sender, UrlEventArgs e)
        {
            //var webView = (WebView)sender;
            //BitmapSurface surface = (BitmapSurface)webView.Surface;
            //surface.SaveToPNG(@"d:\result.png", true);
            //Console.WriteLine("DocumentReady");
        }
    }
}

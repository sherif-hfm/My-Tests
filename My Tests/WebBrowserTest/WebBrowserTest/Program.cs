using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebBrowserTest
{
    class Program
    {
        private static byte[] imageData;
        static void Main(string[] args)
        {

            //var pattern = "(?<label>\"formatter\"): ([\"])(?<tag>.*)([\"])";
            //var replacePattern = "${label}: ${tag}";

            string html = Resource1.Html;
            //string html = "29/12/1437 200/300 <tag></tag>";

            Regex regex = new Regex(@"(\d)/(\d)");
            MatchCollection match = regex.Matches(html);
            

            Regex regex2 = new Regex(@"(\d+)/(\d+)/(\d+)");
            MatchCollection match2 = regex2.Matches(html);

            Regex regex3 = new Regex(@" (\d+)/(\d+) ");
            MatchCollection match3 = regex3.Matches(html);


            //string newstr2 = Regex.Replace(html, @"(\d)/(\d)", @"$1 / $2", RegexOptions.IgnoreCase);

            string newstr3 = Regex.Replace(html, @" (\d+)/(\d+) ", @"<nobr> $2 / $1 </nobr>", RegexOptions.IgnoreCase);
            string newstr = Regex.Replace(newstr3, @"(\d+)/(\d+)/(\d+)", @"<nobr>$3 / $2 / $1</nobr>", RegexOptions.IgnoreCase);



            StartBrowser(newstr);
            //Console.ReadLine();
        }

        private static void StartBrowser(string source)
        {
            var th = new Thread(() =>
            {
                using (var webBrowser = new WebBrowser())
                {
                    webBrowser.ScrollBarsEnabled = false;
                    webBrowser.ScriptErrorsSuppressed = true;
                    webBrowser.DocumentCompleted += webBrowser_DocumentCompleted;
                    webBrowser.Width = 793;
                    webBrowser.Height = 1122;
                    webBrowser.DocumentText = source;
                    Application.Run();
                    File.WriteAllBytes(@"d:\result2.jpg", imageData);
                }
            });
            th.SetApartmentState(ApartmentState.STA);
            th.Start();

        }

        static void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            using (var webBrowser = (WebBrowser)sender)
            {
                using (Bitmap bitmap = new Bitmap(793, 1122))
                {
                    webBrowser.DrawToBitmap(bitmap, new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height));
                    //bitmap.Save(@"d:\result3.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    MemoryStream ms = new MemoryStream();
                    bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    imageData = ms.ToArray();
                    Application.ExitThread();
                }
            }
        }
    }
}

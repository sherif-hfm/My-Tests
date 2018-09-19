using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuesPechkin;

namespace HtmlToImages
{
    class Program
    {
        private static IConverter Pdfconverter =
            new StandardConverter(
                new PdfToolset(
                    new Win64EmbeddedDeployment(
                        new TempFolderDeployment())));

        private static HtmlToPdfDocument pdfDocument = new HtmlToPdfDocument
        {
            Objects =
            {
                new ObjectSettings {    HtmlText=File.ReadAllText(@"d:\web.html") ,WebSettings=new WebSettings(){ DefaultEncoding="UTF8" }}
            }
        };

        private static IConverter imageConverter =
            new ThreadSafeConverter(
                new RemotingToolset<ImageToolset>(
                    new Win64EmbeddedDeployment(
                        new TempFolderDeployment())));

        private static HtmlToImageDocument imgDocument = new HtmlToImageDocument
        {
            In = "http://localhost:8010/test.aspx",
            //In = @"d:\web.html",
            Format = "jpg",
            ScreenWidth = 793,
             Quality=100,
            WebSettings = new WebSettings() {PrintMediaType=true}
        };

        static void Main(string[] args)
        {
            byte[] buf = null;

            try
            {
                //buf = imageConverter.Convert(imgDocument);
                buf = Pdfconverter.Convert(pdfDocument);
                //string fn = @"d:\web.jpg";
                string fn = @"d:\web.pdf";
                //string fn = string.Format("{0}.pdf", Path.GetTempFileName());

                FileStream fs = new FileStream(fn, FileMode.Create);
                fs.Write(buf, 0, buf.Length);
                fs.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

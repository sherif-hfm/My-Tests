using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telerik.Windows.Documents.Flow.FormatProviders.Docx;
using Telerik.Windows.Documents.Flow.FormatProviders.Pdf;
using Telerik.Windows.Documents.Flow.Model;

namespace DocToImageTest
{
    class Program
    {
        static void Main(string[] args)
        {
            UseWordMs3();
            //UseTelerik();
        }

        private static void UseWordMs3()
        {
            using (Process process = new Process())
            {
                process.StartInfo.FileName = @"d:\DocFlow.docx";
                process.StartInfo.Verb = "PrintTo";
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.Start();
                process.WaitForExit();
            }

            var file = Directory.GetFiles(@"d:\", "*DocFlow*.jpg");
            if (file.Length > 0)
            {
                var data = File.ReadAllBytes(file[0]);
            }
        }

        private static void UseWordMs2()
        {
            //FileWatcher();
            var filename = @"d:\DocFlow.docx";
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
            word.Visible = false;

            var doc = word.Documents.Open(filename, ReadOnly: true);
            
            word.ActivePrinter = "ImagePrinter Pro";
            doc.PrintOut();
            
            doc.Close();
            word.Quit();

            Thread.Sleep(3000);
            var file = Directory.GetFiles(@"d:\", "*DocFlow*.jpg");
            if(file.Length > 0)
            {
                var data= File.ReadAllBytes(file[0]);
            }

            Console.ReadLine();
        }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        private static void FileWatcher()
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = @"d:\";
            watcher.Filter = "*.jpg";

            // Add event handlers.
            watcher.Changed += Watcher_Changed;
            watcher.Created += Watcher_Created;

            // Begin watching.
            watcher.EnableRaisingEvents = true;
        }

        private static void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            
        }

        private static void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            
        }

        private static void UseWordMs()
        {
            byte[] imgData = null;
            var filename = @"d:\DocFlow.docx";
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
            word.Visible = false;

            var doc = word.Documents.Open(filename, ReadOnly: true);
            word.ActivePrinter = "";

            //doc.ShowGrammaticalErrors = false;
            //doc.ShowRevisions = false;
            //doc.ShowSpellingErrors = false;
            //word.ActiveDocument.Content.Copy();

            foreach (Microsoft.Office.Interop.Word.Window win in doc.Windows)
            {
                foreach (Microsoft.Office.Interop.Word.Pane pane in win.Panes)
                {
                    int index = 0;
                    foreach (Microsoft.Office.Interop.Word.Page page in pane.Pages)
                    {
                        imgData = page.EnhMetaFileBits;
                        if (imgData != null)
                        {
                            MemoryStream ms = new MemoryStream(imgData);
                            Image temp = Image.FromStream(ms);
                            temp.Save(@"d:\" + index.ToString("00") + ".jpg", ImageFormat.Jpeg);
                            index++;
                        }
                    }
                }
            }



            var data = word.ActiveDocument.Content.EnhMetaFileBits;
            File.WriteAllBytes(@"d:\result.jpg", data);

            //doc.SaveAs2(@"d:\DocFlow.docx.pdf", WdSaveFormat.wdFormatPDF);
            //doc.Close();
            //word.Quit();
        }

        private static void UseTelerik()
        {
            DocxFormatProvider provider = new DocxFormatProvider();
            PdfFormatProvider pdfFormatProvider = new PdfFormatProvider();
            using (Stream input = File.OpenRead(@"d:\DocFlow.docx"))
            {
                RadFlowDocument document = provider.Import(input);
                File.WriteAllBytes(@"d:\DocFlow2.docx", provider.Export(document));
                File.WriteAllBytes(@"d:\DocFlow2.pdf", pdfFormatProvider.Export(document));

            }
        }
    }
}

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ITextSharpTest
{
    /// <summary>
    /// Summary description for PdfCreator
    /// </summary>
    public class PdfCreator : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //using (FileStream fs = new FileStream(@"d:\TextSharp.pdf", FileMode.Create, FileAccess.Write, FileShare.None))


            var data = CreateNewPdf();
            //var data = MergePdf();
            //var data = AddHtml();
            //var data = AddImage();
            context.Response.ContentType = "application/pdf";
            context.Response.BinaryWrite(data);

            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
        }

        private byte[] AddHtml()
        {
            // Document For XMLWorker http://demo.itextsupport.com/xmlworker/itextdoc/flatsite.html
            using (MemoryStream fs = new MemoryStream())
            {
                using (Document doc = new Document(iTextSharp.text.PageSize.A4, 15, 15, 0, 0))
                {
                    using (PdfWriter writer = PdfWriter.GetInstance(doc, fs))
                    {
                        doc.Open();
                        doc.NewPage();
                        var html = "<h1>Welcome to html</h1><br><h2>Welcome to html</h2>";
                        var stringReader = new StringReader(html);
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, stringReader);
                        doc.Close();
                    }
                }
                //File.WriteAllBytes(@"d:\pdf2.pdf", fs.ToArray());
                return fs.ToArray();
            }
        }

        private byte[] CreateNewPdf()
        {
            using (MemoryStream fs = new MemoryStream())
            {
                using (Document doc = new Document(iTextSharp.text.PageSize.A4, 15, 15, 0, 0))
                {
                    using (PdfWriter writer = PdfWriter.GetInstance(doc, fs))
                    {
                        
                        doc.Open();
                        string fontLoc = @"C:\Windows\Fonts\tahoma.ttf"; // make sure to have the correct path to the font file
                        BaseFont bf = BaseFont.CreateFont(fontLoc, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                        Font f = new Font(bf, 24);
                        var text = "اهلا و سهلا";
                        PdfPTable tableau = new PdfPTable(1);
                        tableau.DefaultCell.BorderWidth = 0;
                        tableau.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                        tableau.AddCell(new Phrase(10, text, f));
                        doc.Add(tableau);
                        doc.NewPage();
                        doc.Add(new Paragraph("Hello PDF 2 Page 1"));
                        doc.NewPage();
                        doc.Add(new Paragraph("Hello PDF 2 Page 2"));
                        doc.Close();
                    }
                }
                //File.WriteAllBytes(@"d:\pdf2.pdf", fs.ToArray());
                return fs.ToArray();
            }
        }

        private byte[] AddImage()
        {
            using (MemoryStream fs = new MemoryStream())
            {
                using (Document doc = new Document(iTextSharp.text.PageSize.A4, 15, 15, 0, 0))
                {
                    using (PdfWriter writer = PdfWriter.GetInstance(doc, fs))
                    {
                        doc.Open();

                        iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(@"d:\result.jpg");
                        image.SetAbsolutePosition(0, 0);
                        //doc.SetPageSize(new iTextSharp.text.Rectangle(0, 0, image.Width, image.Height, 0));
                        image.ScaleToFit(doc.PageSize.Width, doc.PageSize.Height);
                        doc.NewPage();
                        doc.Add(image);

                        iTextSharp.text.Image image2 = iTextSharp.text.Image.GetInstance(@"d:\docf.jpg");
                        image2.SetAbsolutePosition(0, 0);
                        //doc.SetPageSize(new iTextSharp.text.Rectangle(0, 0, image2.Width, image2.Height, 0));
                        image2.ScaleToFit(doc.PageSize.Width, doc.PageSize.Height);
                        doc.NewPage();
                        doc.Add(image2);
                        
                        //writer.DirectContent.AddImage(image, false);

                        doc.Close();
                    }
                }
                return fs.ToArray();
            }
        }

        private byte[] MergePdf()
        {
            PdfReader reader = new PdfReader(@"d:\pdf1.pdf");
            PdfReader reader2 = new PdfReader(@"d:\pdf2.pdf");
            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(@"d:\result.jpg");

            using (MemoryStream fs = new MemoryStream())
            {
                using (Document doc = new Document(iTextSharp.text.PageSize.A4, 15, 15, 0, 0))
                {
                    using (PdfWriter writer = PdfWriter.GetInstance(doc, fs))
                    {
                        doc.Open();
                        PdfContentByte cb = writer.DirectContent;
                        
                        // Add Pdf1
                        var pagesNum = reader.NumberOfPages;
                        for (int n = 1; n <= pagesNum; n++)
                        {
                            var page = writer.GetImportedPage(reader, n);
                            doc.NewPage();
                            cb.AddTemplate(page, 0, 0);
                        }
                        
                        // Add Images
                        image.SetAbsolutePosition(0, 0);
                        image.ScaleToFit(doc.PageSize.Width, doc.PageSize.Height);
                        doc.NewPage();
                        doc.Add(image);

                        // Add Pdf2
                        pagesNum = reader.NumberOfPages;
                        for (int n = 1; n <= pagesNum; n++)
                        {
                            var page = writer.GetImportedPage(reader2, n);
                            doc.NewPage();
                            cb.AddTemplate(page, 0, 0);
                        }
                        doc.Close();
                        
                    }
                }
                //File.WriteAllBytes(@"d:\pdf2.pdf", fs.ToArray());
                return fs.ToArray();
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
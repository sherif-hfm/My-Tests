using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

using System.Net;
using iTextSharp.text;
using iTextSharp.text.pdf;
namespace ITextSharp
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void editor_ExportContent(object sender, EditorExportingArgs e)
        {
            return;
            string path = @"d:\text.Pdf";

            using (FileStream fs = File.Create(path))
            {
                Byte[] info = System.Text.Encoding.Default.GetBytes(e.ExportOutput);
                fs.Write(info, 0, info.Length);
            }

            //e.Cancel = true;
        }

         protected void btnSave_Click(object sender, EventArgs e)
        {
            string path = @"d:\text.Pdf";
            var html = editor.GetHtml(EditorStripHtmlOptions.None);
            createPDF(html, path);
            //using (FileStream fs = File.Create(path))
            //{
            //    Byte[] info = null;
            //    doc.Read(info, 0, (int)doc.Length);
            //    fs.Write(info, 0, info.Length);
            //}
        }

         private void createPDF(string html,string _file)
         {
             Document document = new Document();
             //try
             //{
             //    PdfWriter.GetInstance(document, new FileStream(_file, FileMode.Create));
             //    document.Open();
             //    WebClient wc = new WebClient();
             //    string htmlText = html;
             //    Response.Write(htmlText);
             //    //List<IElement> htmlarraylist = HTMLWorker.ParseToList(new StringReader(htmlText), null);
             //    //for (int k = 0; k < htmlarraylist.Count; k++)
             //    //{
             //    //    document.Add((IElement)htmlarraylist[k]);
             //    //}

             //    document.Close();
             //}
             //catch
             //{
             //}
         }


    }
}
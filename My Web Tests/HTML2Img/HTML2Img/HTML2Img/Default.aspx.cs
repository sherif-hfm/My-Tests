using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HTML2Img
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
                  
        }

        private void HtmlToImage()
        {
            /********************************** HTML RENDER Documentation URL  ********************************/
            //https://htmlrenderer.codeplex.com/wikipage?title=Image%20generation&referringTitle=Documentation
            //http://theartofdev.com/html-renderer/


            /********************************** Read html from URL  ********************************/

            //string urlAddress = "http://eservices.alriyadh.gov.sa";

            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
            //HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //if (response.StatusCode == HttpStatusCode.OK)
            //{
            //    Stream receiveStream = response.GetResponseStream();
            //    StreamReader readStream = null;
            //    if (response.CharacterSet == null)
            //    {
            //        readStream = new StreamReader(receiveStream);
            //    }
            //    else
            //    {
            //        readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
            //    }
            //    string data = readStream.ReadToEnd();
            //    response.Close();
            //    readStream.Close();
            //}

            /********************************** move External css To Inline Css ********************************/
            string htmlSource = File.ReadAllText(Server.MapPath("/HtmlPage.html"));
            //var result = PreMailer.Net.PreMailer.MoveCssInline(htmlSource);           
            //var result = PreMailer.Net.PreMailer.MoveCssInline( html :Server.MapPath("/HtmlPage.html"),
            //                                                    removeStyleElements: false,
            //                                                    ignoreElements: null,

            /********************************** save image bitmap & set dpi  ********************************/
            Bitmap m_Bitmap = new Bitmap(793, 1122);
            PointF point = new PointF(0, 0);
            SizeF maxSize = new System.Drawing.SizeF(793, 1122);
            m_Bitmap.SetResolution(96, 96);
            //TheArtOfDev.HtmlRenderer.WinForms.HtmlRender.Render(Graphics.FromImage(m_Bitmap), htmlSource, point, maxSize);
            TheArtOfDev.HtmlRenderer.WinForms.HtmlRender.Render(Graphics.FromImage(m_Bitmap), Resource.html, point, maxSize);
            m_Bitmap.Save(Server.MapPath("/Images/image1_DPI.jpg"));

            /********************************** save image png,jpg ********************************/
            System.Drawing.Image image = TheArtOfDev.HtmlRenderer.WinForms.HtmlRender.RenderToImage(htmlSource, new Size(793, 1122));
            image.Save(Server.MapPath("/Images/image2.jpg"));
        }
    }
}
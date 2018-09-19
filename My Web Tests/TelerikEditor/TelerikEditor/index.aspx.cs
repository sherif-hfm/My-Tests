using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
namespace TelerikEditor
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //editor.Content = "<p style=\"text-align: right;\"><strong>&nbsp;</strong></p>";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            editor.ExportToDocx();
            //editor.ExportToPdf();
        }

        protected void editor_ExportContent(object sender, EditorExportingArgs e)
        {
            string path = @"d:\text.Doc";
            //string path = @"d:\text.pdf";
            
            using (FileStream fs = File.Create(path))
            {
                Byte[] info = System.Text.Encoding.Default.GetBytes(e.ExportOutput);
                fs.Write(info, 0, info.Length);
            }

            e.Cancel = false;
        }

        protected void btnPreview_Click(object sender, EventArgs e)
        {
            string html=editor.GetHtml(EditorStripHtmlOptions.None);
            string result = html;

            
            string pattern = @"<field[^>]*?>(.*?)</field>";
            MatchCollection matches = Regex.Matches(result, pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);
           
            var count = matches.Count;
            while(count > 0)
            {
                var aStringBuilder = new StringBuilder(result);
                var match=matches[0];
                var fieldName = GetFieldName(match.ToString());
                var value = GetValue(match.Groups[1].Value);
                aStringBuilder.Remove(match.Groups[0].Index, match.Groups[0].Length);
                aStringBuilder.Insert(match.Groups[0].Index , value);
                result = aStringBuilder.ToString();
                matches = Regex.Matches(result, pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);
                count = matches.Count;
            }

            divPreview.InnerHtml = result;
        }

        private string GetFieldName(string _str)
        {
            string pattern = "value=\\\"(.*?)\\\"";
            MatchCollection matches = Regex.Matches(_str, pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            if (matches.Count > 0)
            {
                return matches[0].Groups[1].ToString();
            }
            return "";
        }

        private string GetValue(string _str)
        {
            string pattern = @"\[(.*?)\]";
            MatchCollection matches = Regex.Matches(_str, pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            if (matches.Count > 0)
            {
                var aStringBuilder = new StringBuilder(_str);
                var match = matches[0];
                aStringBuilder.Remove(match.Groups[0].Index, match.Groups[0].Length);
                aStringBuilder.Insert(match.Groups[0].Index , "xxx");
                return aStringBuilder.ToString();
            }
            else
                return _str;
        }
    }

    

   
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DocSenderTest
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConvert_Click(object sender, EventArgs e)
        {
            if (fileUploader.UploadedFiles.Count > 0)
            {
                
                Stream fileStream = fileUploader.UploadedFiles[0].InputStream;
                byte[] fileData = new byte[fileStream.Length];
                fileStream.Read(fileData, 0, (int)fileStream.Length);
                FileConvertWCF.FileConvertSrvClient srv = new FileConvertWCF.FileConvertSrvClient();
                var imgData = srv.DocToImageConvert(fileData);
                File.WriteAllBytes(@"d:\result.jpg", imgData);
            }
        }
    }
}
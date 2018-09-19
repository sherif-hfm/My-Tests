using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace TelerikAsyncUpload
{
    public partial class Index : System.Web.UI.Page
    {
        List<UploadDoc> filesData = new List<UploadDoc>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["filesData"] != null)
                filesData = (List<UploadDoc>)Session["filesData"];
            else
            {
                var asd = 1;
            }
            GetFiles();
            
            if (!IsPostBack)
            { 
                LoadData(); 
            }
        }

        private void LoadData()
        {
            UploadDoc item1 = new UploadDoc() { DocName = "Doc1", DocId = 1 };
            UploadDoc item2 = new UploadDoc() { DocName = "Doc2", DocId = 2 };
            UploadDoc item3 = new UploadDoc() { DocName = "Doc3", DocId = 3 };
            UploadDoc item4 = new UploadDoc() { DocName = "Doc4", DocId = 4 };
            filesData.Add(item1);
            filesData.Add(item2);
            filesData.Add(item3);
            filesData.Add(item4);

            rptDataBound();
            
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void rptDataBound()
        {
            rpt.DataSource = filesData;
            rpt.DataBind();
        }

        private void GetFiles()
        {
            List<UploadDoc> data = new List<UploadDoc>();
            foreach (RepeaterItem item in rpt.Items)
            {
                var myuploader = (RadAsyncUpload)item.FindControl("upload1");
                if (myuploader != null)
                {
                    if (myuploader.UploadedFiles.Count > 0)
                    {
                        var fileGuid = myuploader.Attributes["data-FileGuid"];
                        var file = myuploader.UploadedFiles[0];
                        var stream = myuploader.UploadedFiles[0].InputStream;
                        byte[] fileData = new byte[file.ContentLength];
                        int result = stream.Read(fileData, 0, (int)file.ContentLength);

                        UploadDoc dataItem = filesData.Find(f => f.FileGuid == fileGuid);
                        dataItem.FileName = file.FileName;
                        dataItem.IsUploaded = true;
                        dataItem.FileData = fileData;
                    }
                }
            }
            rptDataBound();
        }

        protected override void OnLoadComplete(EventArgs e)
        {
            Session["filesData"] = filesData;
            base.OnLoadComplete(e);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            var fileGuid = ((LinkButton)sender).Attributes["data-FileGuid"];
            UploadDoc dataItem = filesData.Find(f => f.FileGuid == fileGuid);
            dataItem.FileName = "";
            dataItem.IsUploaded = false;
            dataItem.FileData = null;
            rptDataBound();
        }
    }

    public class UploadDoc
    {
        static int FileIndex = 1;
        public UploadDoc()
        {
            FileGuid = FileIndex.ToString();
            FileIndex++;
        }
        public string FileGuid { get; set; }
        public string DocName { get; set; }
        public int DocId { get; set; }
        public string FileName { get; set; }
        public bool IsUploaded { get; set; }
        public byte[] FileData { get; set; }
    }
}
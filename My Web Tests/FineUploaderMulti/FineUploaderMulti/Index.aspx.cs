using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FineUploaderMulti
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblSession.Text = Session.SessionID;
            Session["Val"] = "Val";
            BindUploadDocs();
                
        }

        private void BindUploadDocs()
        {
            List<UploadDocument> DocList = new List<UploadDocument>();
            UploadDocument doc1 = new UploadDocument() { DocId = "1", DocName = "Doc1", Mandatory = true ,AllowMulti = false };
            UploadDocument doc2 = new UploadDocument() { DocId = "2", DocName = "Doc2", Mandatory = true, AllowMulti = false };
            UploadDocument doc3 = new UploadDocument() { DocId = "3", DocName = "Doc3", Mandatory = true, AllowMulti = false };
            UploadDocument doc4 = new UploadDocument() { DocId = "4", DocName = "Doc4", Mandatory = true, AllowMulti = false };
            DocList.Add(doc1);
            DocList.Add(doc2);
            DocList.Add(doc3);
            DocList.Add(doc4);
            RmMultiUploader.SetDocList(DocList);
        }

        protected void btnBind_Click(object sender, EventArgs e)
        {
            BindUploadDocs();
        }
    }
}
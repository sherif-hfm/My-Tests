using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FineUploaderMulti
{
    public partial class RmMultiUploader : System.Web.UI.UserControl
    {
        private List<UploadDocument> DocList;
        protected void Page_Load(object sender, EventArgs e)
        {
            BindUploadDocs();
        }

        public void SetDocList(List<UploadDocument> _docList)
        {
            DocList = _docList;
            Session["UploadDocList"] = _docList;
            BindUploadDocs();
        }

        

        protected override void OnInit(EventArgs e)
        {
            if (Session["UploadDocList"] != null)
                DocList = (List<UploadDocument>)Session["UploadDocList"];
            base.OnInit(e);
        }

        protected override void OnUnload(EventArgs e)
        {
            Session["UploadDocList"] = DocList;
            base.OnUnload(e);
        }

        private void BindUploadDocs()
        {
            rptDocs.DataSource = DocList;
            rptDocs.DataBind();
        }


        protected void rptDocs_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var fileRpt = (Repeater)e.Item.FindControl("rptFile");
            var dataItem = (UploadDocument)e.Item.DataItem;
            if (dataItem.UploadFiles != null)
            {
                fileRpt.DataSource = dataItem.UploadFiles;
                fileRpt.DataBind();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WcfAddRef
{
    public partial class index : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            ESCTSService.ESCTSServiceImplService srv = new ESCTSService.ESCTSServiceImplService();
            ESCTSService.documentFullInfo rq=new ESCTSService.documentFullInfo();
            //rq.document_number = "3600225550";
            rq.document_number = "3000000111";
            //rq.document_number = "3600005208";
            var result = srv.getDocumentInfo("admin", "admin", rq);
            //var result = srv.GetDocumentStatus("admin", "admin");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CallWcfTest.DocFlowWCF;
using Riyadh.EServices.WebHttp;
using Riyadh.EServices.Model.DocFlow;
namespace CallWcfTest
{
    class Program
    {
        static void Main(string[] args)
        {
            CallWcf2();
        }

        private static void CallWcf()
        {
            DocFlowWCF.DocFlowClient srv = new DocFlowClient();
            var result = srv.SearchAllDocs(new CallWcfTest.DocFlowWCF.DocSearchParameters() { DocReference = "1700024668" }, 1);
        }

        private static void CallWcf2()
        {
            var docflowClient = RmServices.GetWsService<Riyadh.EServices.IServices.DocFlow.IDocFlow>();
            var result = docflowClient.SearchAllDocs(new Riyadh.EServices.Model.DocFlow.DocSearchParameters { DocReference = "1700024668" }, 1);
        }
    }
}

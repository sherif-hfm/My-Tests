using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using System.Configuration;
using System.Data;
namespace CallOracleStoredProcedure
{
    class Program
    {
        static void Main(string[] args)
        {
            string cnnStr = ConfigurationManager.AppSettings["Main.ConnectionString"];
            DbHelper dbHelper = new DbHelper(cnnStr);
            
            SearchParameters prms = new SearchParameters() { TransferFromDepartmentCode = 1 };
            var tab = dbHelper.ExecuteReader<SearchParameters, SearchFollowDocsResult>("DOCFLOW.DocFlow_web.Search_Follow_Docs", prms, "", "");
            //var tab11 = dbHelper.ExecuteReader<SearchParameters>("DOCFLOW.DocFlow_web.Search_Follow_Docs", prms, "");
            
            
            
            //var tab1 = dbHelper.ExecuteReader("DOCFLOW.DocFlow_web.Search_Follow_Docs", new { pTransfer_From_Department_Code = 1 });
            //var tab2 = dbHelper.ExecuteReader("DOCFLOW.DocFlow_web.Get_Organizations", new { });

            //var tab1 = dbHelper.ExecuteReader<SearchFollowDocsResult>("DOCFLOW.DocFlow_web.Search_Follow_Docs", new { pTransfer_From_Department_Code = (decimal)1 }, "");
            
            //var tab3 = dbHelper.ExecuteNonQuery("DOCFLOW.DocFlow_web.IS_Annexation_Added", new { pREFERENCE_NUMBER = 3700141870, pTRANSFER_SEQUENCE = 4 });

            //SearchParameters2 searchPrm1 = new SearchParameters2() { ReferenceNo = "3700141870", TransferSequence = 4 };
            //SearchParametersPrnt searchPrm = new SearchParametersPrnt() { SearchParameters = searchPrm1, ReferenceNo = "1" };
            //var tab4 = dbHelper.ExecuteNonQuery<SearchParametersPrnt>("DOCFLOW.DocFlow_web.IS_Annexation_Added", searchPrm, "");
            
        }
    }
}



using RM.DatabaseSpecific;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
//using Oracle.DataAccess.Client;
using System.Data.OracleClient;
namespace llblOldTest
{
    class Program
    {
        static void Main(string[] args)
        {
            CallCmd();
        }


        private static void CallCmd()
        {
            var connStr = System.Configuration.ConfigurationManager.AppSettings["Main.ConnectionString"].ToString();
            try
            {
                OracleConnection cnn = new OracleConnection(connStr);
                OracleCommand cmd = new OracleCommand("RVU.SADAD_PKG.NEW_INVOICE_EXP_DATE_SEC", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                DbParameter[] prms = new DbParameter[18];
                prms[0] = new OracleParameter("return_value", OracleType.NVarChar) { Size = 500, Direction = ParameterDirection.ReturnValue };
                //prms[0] = new OracleParameter("return_value", OracleDbType.Varchar2) { Size = 500, Direction = ParameterDirection.ReturnValue };
                prms[1] = new OracleParameter("P_FORM_AMOUNT", 6220);
                prms[2] = new OracleParameter("P_BENEFICIARY_CODE", 1);
                prms[3] = new OracleParameter("P_ID_TYPE", 1);
                prms[4] = new OracleParameter("P_ID_NO",  "1001154887");
                prms[5] = new OracleParameter("P_BENEFICIARY_NAME", "");
                prms[6] = new OracleParameter("P_SERVICE_CODE", 1);
                prms[7] = new OracleParameter("P_SERVICE_SUB_CODE", 1);
                prms[8] = new OracleParameter("P_DIR_CODE", "49");
                prms[9] = new OracleParameter("P_APPL_CODE", "TLS");
                prms[10] = new OracleParameter("P_COMMIT", 1);
                prms[11] = new OracleParameter("P_RECEIPT_NO", null);
                prms[12] = new OracleParameter("P_RECEIPT_GRP", null);
                prms[13] = new OracleParameter("P_REMARKS", "");
                prms[14] = new OracleParameter("P_EXP_DATE", DateTime.Now);
                prms[15] = new OracleParameter("P_USER_CODE", "2094");
                prms[16] = new OracleParameter("P_SECTION_CODE", null);
                prms[17] = new OracleParameter("P_WEB", 1);
                cmd.Parameters.AddRange(prms);
                cnn.Open();
                cmd.ExecuteNonQuery();
                //OracleHelper.OracleHelper.ExecuteNonQuery(connStr, "RVU.SADAD_PKG.NEW_INVOICE_EXP_DATE_SEC", prms);
                cnn.Close();
                var result = prms[0].Value.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            
        }

        //private static void CallHelperCmd()
        //{

        //    var connStr = System.Configuration.ConfigurationManager.AppSettings["Main.ConnectionString"].ToString();
        //    try
        //    {
        //        int iOwnerIdTypeCode = 1;

        //        var P_FORM_AMOUNT = new OracleParameter("P_FORM_AMOUNT",  6220);
        //        var P_BENEFICIARY_CODE = new OracleParameter("P_BENEFICIARY_CODE",  1);
        //        var P_ID_TYPE = new OracleParameter("P_ID_TYPE",  1);
        //        var P_ID_NO = new OracleParameter("P_ID_NO",  "1001154887");
        //        var P_BENEFICIARY_NAME = new OracleParameter("P_BENEFICIARY_NAME",  "");
        //        var P_SERVICE_CODE = new OracleParameter("P_SERVICE_CODE",  1);
        //        var P_SERVICE_SUB_CODE = new OracleParameter("P_SERVICE_SUB_CODE", 1 );
        //        var P_DIR_CODE = new OracleParameter("P_DIR_CODE",  "49" );
        //        var P_APPL_CODE = new OracleParameter("P_APPL_CODE", "TLS");
        //        var P_COMMIT = new OracleParameter("P_COMMIT",  1);
        //        var P_RECEIPT_NO = new OracleParameter("P_RECEIPT_NO" ,null);
        //        var P_RECEIPT_GRP = new OracleParameter("P_RECEIPT_GRP",null);
        //        var P_REMARKS = new OracleParameter("P_REMARKS",  "");
        //        var P_EXP_DATE = new OracleParameter("P_EXP_DATE", DateTime.Now);
        //        var P_USER_CODE = new OracleParameter("P_USER_CODE",  "2094");
        //        var P_SECTION_CODE = new OracleParameter("P_SECTION_CODE" , null);
        //        var P_WEB = new OracleParameter("P_WEB", 1);

        //        var preturn = new OracleParameter("return_value", OracleDbType.NVarchar2, System.Data.ParameterDirection.ReturnValue) { Size = 500 };

        //        OracleHelper.OracleHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "RVU.SADAD_PKG.NEW_INVOICE_EXP_DATE_SEC",
        //            preturn, P_FORM_AMOUNT, P_BENEFICIARY_CODE, P_ID_TYPE, P_ID_NO, P_BENEFICIARY_NAME, P_SERVICE_CODE, P_SERVICE_SUB_CODE, P_DIR_CODE, P_APPL_CODE, P_COMMIT, P_RECEIPT_NO, P_RECEIPT_GRP,
        //            P_REMARKS, P_EXP_DATE, P_USER_CODE, P_SECTION_CODE, P_WEB);

        //        var result = preturn.Value.ToString();
               
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        private static void CallLLBL()
        {
            try
            {
                string strBillAccount = string.Empty;
                RM.DatabaseSpecific.DataAccessAdapter adapter = new RM.DatabaseSpecific.DataAccessAdapter();
                var data = RM.DatabaseSpecific.ActionProcedures.Sadad_PkgNew_Invoice_Exp_Date_Sec(6220, 1, 1, "1001154887", ""
                    , 1, 1, "49", "TLS", 0, 0, 0, "", null, "2094", "", 1, ref strBillAccount, adapter);
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}

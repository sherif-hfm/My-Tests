using LLBLGen.DatabaseSpecific;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace llblTest
{
    class Program
    {
        static void Main(string[] args)
        {
                //OracleParameter[] parameters = new OracleParameter[] { 
                //new OracleParameter("RETURN_VALUE", OracleType.VarChar, 4000, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, ActionProcedures.ConvertNullToDBNull(return_Value)), 
                //new OracleParameter("P_FORM_AMOUNT", OracleType.Number, 0, ParameterDirection.Input, true, 22, 0, "", DataRowVersion.Current, ActionProcedures.ConvertNullToDBNull(p_Form_Amount)), 
                //new OracleParameter("P_BENEFICIARY_CODE", OracleType.Number, 0, ParameterDirection.Input, true, 22, 0, "", DataRowVersion.Current, ActionProcedures.ConvertNullToDBNull(p_Beneficiary_Code)), 
                //new OracleParameter("P_ID_TYPE", OracleType.Number, 0, ParameterDirection.Input, true, 22, 0, "", DataRowVersion.Current, ActionProcedures.ConvertNullToDBNull(p_Id_Type)), 
                //new OracleParameter("P_ID_NO", OracleType.VarChar, 4000, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Current, ActionProcedures.ConvertNullToDBNull(p_Id_No)), 
                //new OracleParameter("P_BENEFICIARY_NAME", OracleType.VarChar, 4000, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Current, ActionProcedures.ConvertNullToDBNull(p_Beneficiary_Name)), 
                //new OracleParameter("P_SERVICE_CODE", OracleType.Number, 0, ParameterDirection.Input, true, 22, 0, "", DataRowVersion.Current, ActionProcedures.ConvertNullToDBNull(p_Service_Code)), 
                //new OracleParameter("P_SERVICE_SUB_CODE", OracleType.Number, 0, ParameterDirection.Input, true, 22, 0, "", DataRowVersion.Current, ActionProcedures.ConvertNullToDBNull(p_Service_Sub_Code)), 
                //new OracleParameter("P_DIR_CODE", OracleType.VarChar, 4000, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Current, ActionProcedures.ConvertNullToDBNull(p_Dir_Code)), 
                //new OracleParameter("P_APPL_CODE", OracleType.VarChar, 4000, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Current, ActionProcedures.ConvertNullToDBNull(p_Appl_Code)), 
                //new OracleParameter("P_COMMIT", OracleType.Number, 0, ParameterDirection.Input, true, 22, 0, "", DataRowVersion.Current, ActionProcedures.ConvertNullToDBNull(p_Commit)),
                //new OracleParameter("P_RECEIPT_NO", OracleType.Number, 0, ParameterDirection.Input, true, 22, 0, "", DataRowVersion.Current, ActionProcedures.ConvertNullToDBNull(p_Receipt_No)), 
                //new OracleParameter("P_RECEIPT_GRP", OracleType.Number, 0, ParameterDirection.Input, true, 22, 0, "", DataRowVersion.Current, ActionProcedures.ConvertNullToDBNull(p_Receipt_Grp)), 
                //new OracleParameter("P_REMARKS", OracleType.VarChar, 4000, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Current, ActionProcedures.ConvertNullToDBNull(p_Remarks)), 
                //new OracleParameter("P_EXP_DATE", OracleType.DateTime, 0, ParameterDirection.Input, true, 19, 0, "", DataRowVersion.Current, ActionProcedures.ConvertNullToDBNull(p_Exp_Date)), 
                //new OracleParameter("P_USER_CODE", OracleType.VarChar, 4000, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Current, ActionProcedures.ConvertNullToDBNull(p_User_Code)), 
                //new OracleParameter("P_SECTION_CODE", OracleType.VarChar, 4000, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Current, ActionProcedures.ConvertNullToDBNull(p_Section_Code)), 
                //new OracleParameter("WEB", OracleType.Number, 0, ParameterDirection.Input, true, 22, 0, "", DataRowVersion.Current, ActionProcedures.ConvertNullToDBNull(web)) };
            string returnStr="";
            DataAccessAdapter adapter = new LLBLGen.DatabaseSpecific.DataAccessAdapter();
            adapter.StartTransaction(System.Data.IsolationLevel.Serializable, "Save Trading License");
            var data = LLBLGen.DatabaseSpecific.ActionProcedures.SadadPkgNewInvoiceExpDateSec(6220, 1, 1, "1001154887", "احمد بن محمد بن عبدالحافظ شيهون"
                , 1, 1, "45", "TLS", 0, 0, 0, "", DateTime.Now, "2094", null, 1, ref returnStr, adapter);

            adapter.Rollback();
        }
    }
}

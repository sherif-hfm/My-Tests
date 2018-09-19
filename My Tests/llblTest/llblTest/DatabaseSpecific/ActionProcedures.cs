///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 4.2
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using System.Data;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace LLBLGen.DatabaseSpecific
{
	/// <summary>Class which contains the static logic to execute action stored procedures in the database.</summary>
	public static partial class ActionProcedures
	{

		/// <summary>Delegate definition for stored procedure 'SADAD_PKG.NEW_INVOICE_EXP_DATE_SEC' to be used in combination of a UnitOfWork2 object.</summary>
		public delegate int SadadPkgNewInvoiceExpDateSecCallBack(System.Decimal pFormAmount, System.Decimal pBeneficiaryCode, System.Decimal pIdType, System.String pIdNo, System.String pBeneficiaryName, System.Decimal pServiceCode, System.Decimal pServiceSubCode, System.String pDirCode, System.String pApplCode, System.Decimal pCommit, System.Decimal pReceiptNo,  
System.Decimal pReceiptGrp, System.String pRemarks, System.DateTime pExpDate, System.String pUserCode, System.String pSectionCode, System.Decimal pWeb, ref System.String returnValue, IDataAccessCore dataAccessProvider);


		/// <summary>Calls stored procedure 'SADAD_PKG.NEW_INVOICE_EXP_DATE_SEC'.<br/><br/></summary>
		/// <param name="returnValue">ReturnValue parameter. </param>
		/// <param name="pFormAmount">Input parameter. </param>
		/// <param name="pBeneficiaryCode">Input parameter. </param>
		/// <param name="pIdType">Input parameter. </param>
		/// <param name="pIdNo">Input parameter. </param>
		/// <param name="pBeneficiaryName">Input parameter. </param>
		/// <param name="pServiceCode">Input parameter. </param>
		/// <param name="pServiceSubCode">Input parameter. </param>
		/// <param name="pDirCode">Input parameter. </param>
		/// <param name="pApplCode">Input parameter. </param>
		/// <param name="pCommit">Input parameter. </param>
		/// <param name="pReceiptNo">Input parameter. </param>
		/// <param name="pReceiptGrp">Input parameter. </param>
		/// <param name="pRemarks">Input parameter. </param>
		/// <param name="pExpDate">Input parameter. </param>
		/// <param name="pUserCode">Input parameter. </param>
		/// <param name="pSectionCode">Input parameter. </param>
		/// <param name="pWeb">Input parameter. </param>
		/// <returns>Number of rows affected, if the database / routine doesn't suppress rowcounting.</returns>
		public static int SadadPkgNewInvoiceExpDateSec(System.Decimal pFormAmount, System.Decimal pBeneficiaryCode, System.Decimal pIdType, System.String pIdNo, System.String pBeneficiaryName, System.Decimal pServiceCode, System.Decimal pServiceSubCode, System.String pDirCode, System.String pApplCode, System.Decimal pCommit, System.Decimal pReceiptNo,  
System.Decimal pReceiptGrp, System.String pRemarks, System.DateTime pExpDate, System.String pUserCode, System.String pSectionCode, System.Decimal pWeb, ref System.String returnValue)
		{
			using(DataAccessAdapter dataAccessProvider = new DataAccessAdapter())
			{
				return SadadPkgNewInvoiceExpDateSec(pFormAmount, pBeneficiaryCode, pIdType, pIdNo, pBeneficiaryName, pServiceCode, pServiceSubCode, pDirCode, pApplCode, pCommit, pReceiptNo,  
pReceiptGrp, pRemarks, pExpDate, pUserCode, pSectionCode, pWeb, ref returnValue, dataAccessProvider);
			}
		}

		/// <summary>Calls stored procedure 'SADAD_PKG.NEW_INVOICE_EXP_DATE_SEC'.<br/><br/></summary>
		/// <param name="dataAccessProvider">The data access provider.</param>
		/// <param name="returnValue">ReturnValue parameter. </param>
		/// <param name="pFormAmount">Input parameter. </param>
		/// <param name="pBeneficiaryCode">Input parameter. </param>
		/// <param name="pIdType">Input parameter. </param>
		/// <param name="pIdNo">Input parameter. </param>
		/// <param name="pBeneficiaryName">Input parameter. </param>
		/// <param name="pServiceCode">Input parameter. </param>
		/// <param name="pServiceSubCode">Input parameter. </param>
		/// <param name="pDirCode">Input parameter. </param>
		/// <param name="pApplCode">Input parameter. </param>
		/// <param name="pCommit">Input parameter. </param>
		/// <param name="pReceiptNo">Input parameter. </param>
		/// <param name="pReceiptGrp">Input parameter. </param>
		/// <param name="pRemarks">Input parameter. </param>
		/// <param name="pExpDate">Input parameter. </param>
		/// <param name="pUserCode">Input parameter. </param>
		/// <param name="pSectionCode">Input parameter. </param>
		/// <param name="pWeb">Input parameter. </param>
		/// <returns>Number of rows affected, if the database / routine doesn't suppress rowcounting.</returns>
		public static int SadadPkgNewInvoiceExpDateSec(System.Decimal pFormAmount, System.Decimal pBeneficiaryCode, System.Decimal pIdType, System.String pIdNo, System.String pBeneficiaryName, System.Decimal pServiceCode, System.Decimal pServiceSubCode, System.String pDirCode, System.String pApplCode, System.Decimal pCommit, System.Decimal pReceiptNo,  
System.Decimal pReceiptGrp, System.String pRemarks, System.DateTime pExpDate, System.String pUserCode, System.String pSectionCode, System.Decimal pWeb, ref System.String returnValue, IDataAccessCore dataAccessProvider)
		{
			using(StoredProcedureCall call = CreateSadadPkgNewInvoiceExpDateSecCall(dataAccessProvider, pFormAmount, pBeneficiaryCode, pIdType, pIdNo, pBeneficiaryName, pServiceCode, pServiceSubCode, pDirCode, pApplCode, pCommit, pReceiptNo,  
pReceiptGrp, pRemarks, pExpDate, pUserCode, pSectionCode, pWeb, returnValue))
			{
				int toReturn = call.Call();
				returnValue = call.GetParameterValue<System.String>(0);
				return toReturn;
			}
		}
		
		/// <summary>Creates the call object for the call 'SadadPkgNewInvoiceExpDateSec' to stored procedure 'SADAD_PKG.NEW_INVOICE_EXP_DATE_SEC'.</summary>
		/// <param name="dataAccessProvider">The data access provider.</param>
		/// <param name="returnValue">ReturnValue parameter</param>
		/// <param name="pFormAmount">Input parameter</param>
		/// <param name="pBeneficiaryCode">Input parameter</param>
		/// <param name="pIdType">Input parameter</param>
		/// <param name="pIdNo">Input parameter</param>
		/// <param name="pBeneficiaryName">Input parameter</param>
		/// <param name="pServiceCode">Input parameter</param>
		/// <param name="pServiceSubCode">Input parameter</param>
		/// <param name="pDirCode">Input parameter</param>
		/// <param name="pApplCode">Input parameter</param>
		/// <param name="pCommit">Input parameter</param>
		/// <param name="pReceiptNo">Input parameter</param>
		/// <param name="pReceiptGrp">Input parameter</param>
		/// <param name="pRemarks">Input parameter</param>
		/// <param name="pExpDate">Input parameter</param>
		/// <param name="pUserCode">Input parameter</param>
		/// <param name="pSectionCode">Input parameter</param>
		/// <param name="pWeb">Input parameter</param>
		/// <returns>Ready to use StoredProcedureCall object</returns>
		private static StoredProcedureCall CreateSadadPkgNewInvoiceExpDateSecCall(IDataAccessCore dataAccessProvider, System.Decimal pFormAmount, System.Decimal pBeneficiaryCode, System.Decimal pIdType, System.String pIdNo, System.String pBeneficiaryName, System.Decimal pServiceCode, System.Decimal pServiceSubCode, System.String pDirCode, System.String pApplCode, System.Decimal pCommit, System.Decimal pReceiptNo,  
System.Decimal pReceiptGrp, System.String pRemarks, System.DateTime pExpDate, System.String pUserCode, System.String pSectionCode, System.Decimal pWeb, System.String returnValue)
		{
			return new StoredProcedureCall(dataAccessProvider, "\"RVU\".\"SADAD_PKG.NEW_INVOICE_EXP_DATE_SEC\"", "SadadPkgNewInvoiceExpDateSec")
							.AddParameter("RETURN_VALUE", "Varchar2", 4000, ParameterDirection.ReturnValue, true, 0, 0, returnValue)
							.AddParameter("P_FORM_AMOUNT", "Decimal", 0, ParameterDirection.Input, true, 38, 38, pFormAmount)
							.AddParameter("P_BENEFICIARY_CODE", "Decimal", 0, ParameterDirection.Input, true, 38, 38, pBeneficiaryCode)
							.AddParameter("P_ID_TYPE", "Decimal", 0, ParameterDirection.Input, true, 38, 38, pIdType)
							.AddParameter("P_ID_NO", "Varchar2", 4000, ParameterDirection.Input, true, 0, 0, pIdNo)
							.AddParameter("P_BENEFICIARY_NAME", "Varchar2", 4000, ParameterDirection.Input, true, 0, 0, pBeneficiaryName)
							.AddParameter("P_SERVICE_CODE", "Decimal", 0, ParameterDirection.Input, true, 38, 38, pServiceCode)
							.AddParameter("P_SERVICE_SUB_CODE", "Decimal", 0, ParameterDirection.Input, true, 38, 38, pServiceSubCode)
							.AddParameter("P_DIR_CODE", "Varchar2", 4000, ParameterDirection.Input, true, 0, 0, pDirCode)
							.AddParameter("P_APPL_CODE", "Varchar2", 4000, ParameterDirection.Input, true, 0, 0, pApplCode)
							.AddParameter("P_COMMIT", "Decimal", 0, ParameterDirection.Input, true, 38, 38, pCommit) 

							.AddParameter("P_RECEIPT_NO", "Decimal", 0, ParameterDirection.Input, true, 38, 38, pReceiptNo)
							.AddParameter("P_RECEIPT_GRP", "Decimal", 0, ParameterDirection.Input, true, 38, 38, pReceiptGrp)
							.AddParameter("P_REMARKS", "Varchar2", 4000, ParameterDirection.Input, true, 0, 0, pRemarks)
							.AddParameter("P_EXP_DATE", "Date", 0, ParameterDirection.Input, true, 0, 0, pExpDate)
							.AddParameter("P_USER_CODE", "Varchar2", 4000, ParameterDirection.Input, true, 0, 0, pUserCode)
							.AddParameter("P_SECTION_CODE", "Varchar2", 4000, ParameterDirection.Input, true, 0, 0, pSectionCode)
							.AddParameter("P_WEB", "Decimal", 0, ParameterDirection.Input, true, 38, 38, pWeb);
		}


		#region Included Code

		#endregion
	}
}

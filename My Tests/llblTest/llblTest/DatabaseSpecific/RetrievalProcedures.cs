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
using System.Collections.Generic;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.LLBLGen.Pro.QuerySpec.Adapter;

namespace LLBLGen.DatabaseSpecific
{
	/// <summary>Class which contains the static logic to execute retrieval stored procedures in the database.</summary>
	public static partial class RetrievalProcedures
	{


		/// <summary>Calls stored procedure 'WEB_SECURITY_PKG.GET_USER_MENU'.<br/><br/></summary>
		/// <param name="pUserCode">Input parameter. </param>
		/// <param name="pUserType">Input parameter. </param>
		/// <returns>Filled DataSet with resultset(s) of stored procedure</returns>
		public static DataSet WebSecurityPkgGetUserMenu(System.String pUserCode, System.Decimal pUserType)
		{
			using(DataAccessAdapter dataAccessProvider = new DataAccessAdapter())
			{
				return WebSecurityPkgGetUserMenu(pUserCode, pUserType, dataAccessProvider);
			}
		}

		/// <summary>Calls stored procedure 'WEB_SECURITY_PKG.GET_USER_MENU'.<br/><br/></summary>
		/// <param name="dataAccessProvider">The data access provider.</param>
		/// <param name="pUserCode">Input parameter. </param>
		/// <param name="pUserType">Input parameter. </param>
		/// <returns>Filled DataSet with resultset(s) of stored procedure</returns>
		public static DataSet WebSecurityPkgGetUserMenu(System.String pUserCode, System.Decimal pUserType, IDataAccessCore dataAccessProvider)
		{
			using(StoredProcedureCall call = CreateWebSecurityPkgGetUserMenuCall(dataAccessProvider, pUserCode, pUserType))
			{
				DataSet toReturn = call.FillDataSet();
				return toReturn;
			}
		}

		/// <summary>Creates an IRetrievalQuery object for a call to the procedure 'WEB_SECURITY_PKG.GET_USER_MENU'.</summary>
		/// <param name="pUserCode">Input parameter of stored procedure</param>
		/// <param name="pUserType">Input parameter of stored procedure</param>
		/// <returns>IRetrievalQuery object which is ready to use for datafetching</returns>
		public static IRetrievalQuery GetWebSecurityPkgGetUserMenuCallAsQuery(System.String pUserCode, System.Decimal pUserType)
		{
			using(DataAccessAdapter dataAccessProvider = new DataAccessAdapter())
			{
				return CreateWebSecurityPkgGetUserMenuCall(dataAccessProvider, pUserCode, pUserType).ToRetrievalQuery();
			}
		}

		/// <summary>Creates the call object for the call 'WebSecurityPkgGetUserMenu' to stored procedure 'WEB_SECURITY_PKG.GET_USER_MENU'.</summary>
		/// <param name="dataAccessProvider">The data access provider.</param>
		/// <param name="pUserCode">Input parameter</param>
		/// <param name="pUserType">Input parameter</param>
		/// <returns>Ready to use StoredProcedureCall object</returns>
		private static StoredProcedureCall CreateWebSecurityPkgGetUserMenuCall(IDataAccessCore dataAccessProvider, System.String pUserCode, System.Decimal pUserType)
		{
			object workRec = null;
			return new StoredProcedureCall(dataAccessProvider, "\"EWEB_USER\".\"WEB_SECURITY_PKG.GET_USER_MENU\"", "WebSecurityPkgGetUserMenu")
							.AddParameter("P_USER_CODE", "Varchar2", 4000, ParameterDirection.Input, true, 0, 0, pUserCode)
							.AddParameter("P_USER_TYPE", "Decimal", 0, ParameterDirection.Input, true, 38, 38, pUserType)
							.AddParameter("WORK_REC", "RefCursor", 0, ParameterDirection.Output, true, 0, 0, workRec);
		}


		#region Included Code

		#endregion
	}
}

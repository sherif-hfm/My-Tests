///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 4.2
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
//////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Data;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace LLBLGen.DatabaseSpecific
{
	/// <summary>Singleton implementation of the PersistenceInfoProvider. This class is the singleton wrapper through which the actual instance is retrieved.</summary>
	/// <remarks>It uses a single instance of an internal class. The access isn't marked with locks as the PersistenceInfoProviderBase class is threadsafe.</remarks>
	internal static class PersistenceInfoProviderSingleton
	{
		#region Class Member Declarations
		private static readonly IPersistenceInfoProvider _providerInstance = new PersistenceInfoProviderCore();
		#endregion

		/// <summary>Dummy static constructor to make sure threadsafe initialization is performed.</summary>
		static PersistenceInfoProviderSingleton()
		{
		}

		/// <summary>Gets the singleton instance of the PersistenceInfoProviderCore</summary>
		/// <returns>Instance of the PersistenceInfoProvider.</returns>
		public static IPersistenceInfoProvider GetInstance()
		{
			return _providerInstance;
		}
	}

	/// <summary>Actual implementation of the PersistenceInfoProvider. Used by singleton wrapper.</summary>
	internal class PersistenceInfoProviderCore : PersistenceInfoProviderBase
	{
		/// <summary>Initializes a new instance of the <see cref="PersistenceInfoProviderCore"/> class.</summary>
		internal PersistenceInfoProviderCore()
		{
			Init();
		}

		/// <summary>Method which initializes the internal datastores with the structure of hierarchical types.</summary>
		private void Init()
		{
			this.InitClass(2);
			InitWebFunctionEntityMappings();
			InitWebRoleEntityMappings();
		}

		/// <summary>Inits WebFunctionEntity's mappings</summary>
		private void InitWebFunctionEntityMappings()
		{
			this.AddElementMapping("WebFunctionEntity", @"RMDEV", @"EWEB_USER", "WEB_FUNCTIONS", 10, 0);
			this.AddElementFieldMapping("WebFunctionEntity", "DefaultApp", "DEFAULT_APP", true, "Varchar2", 20, 0, 0, false, "", null, typeof(System.String), 0);
			this.AddElementFieldMapping("WebFunctionEntity", "DefaultParent", "DEFAULT_PARENT", true, "Varchar2", 20, 0, 0, false, "", null, typeof(System.String), 1);
			this.AddElementFieldMapping("WebFunctionEntity", "DefaultSort", "DEFAULT_SORT", true, "Decimal", 0, 4, 0, false, "", null, typeof(System.Int16), 2);
			this.AddElementFieldMapping("WebFunctionEntity", "DisableCode", "DISABLE_CODE", true, "Decimal", 0, 3, 0, false, "", null, typeof(System.Int16), 3);
			this.AddElementFieldMapping("WebFunctionEntity", "DisableDate", "DISABLE_DATE", true, "Date", 0, 0, 0, false, "", null, typeof(System.DateTime), 4);
			this.AddElementFieldMapping("WebFunctionEntity", "FunctionAname", "FUNCTION_ANAME", false, "Varchar2", 100, 0, 0, false, "", null, typeof(System.String), 5);
			this.AddElementFieldMapping("WebFunctionEntity", "FunctionEname", "FUNCTION_ENAME", false, "Varchar2", 100, 0, 0, false, "", null, typeof(System.String), 6);
			this.AddElementFieldMapping("WebFunctionEntity", "FunctionId", "FUNCTION_ID", false, "Varchar2", 20, 0, 0, false, "", null, typeof(System.String), 7);
			this.AddElementFieldMapping("WebFunctionEntity", "FunctionUrl", "FUNCTION_URL", true, "Varchar2", 200, 0, 0, false, "", null, typeof(System.String), 8);
			this.AddElementFieldMapping("WebFunctionEntity", "Visible", "VISIBLE", false, "Decimal", 0, 1, 0, false, "", null, typeof(System.Int16), 9);
		}

		/// <summary>Inits WebRoleEntity's mappings</summary>
		private void InitWebRoleEntityMappings()
		{
			this.AddElementMapping("WebRoleEntity", @"RMDEV", @"EWEB_USER", "WEB_ROLE", 5, 0);
			this.AddElementFieldMapping("WebRoleEntity", "DefaultFunction", "DEFAULT_FUNCTION", true, "Varchar2", 10, 0, 0, false, "", null, typeof(System.String), 0);
			this.AddElementFieldMapping("WebRoleEntity", "DisableCode", "DISABLE_CODE", true, "Decimal", 0, 3, 0, false, "", null, typeof(System.Int16), 1);
			this.AddElementFieldMapping("WebRoleEntity", "DisableDate", "DISABLE_DATE", true, "Date", 0, 0, 0, false, "", null, typeof(System.DateTime), 2);
			this.AddElementFieldMapping("WebRoleEntity", "RoleCode", "ROLE_CODE", false, "Varchar2", 20, 0, 0, false, "", null, typeof(System.String), 3);
			this.AddElementFieldMapping("WebRoleEntity", "RoleDesc", "ROLE_DESC", true, "Varchar2", 100, 0, 0, false, "", null, typeof(System.String), 4);
		}

	}
}

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
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace LLBLGen.HelperClasses
{
	
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END
	
	/// <summary>Singleton implementation of the FieldInfoProvider. This class is the singleton wrapper through which the actual instance is retrieved.</summary>
	/// <remarks>It uses a single instance of an internal class. The access isn't marked with locks as the FieldInfoProviderBase class is threadsafe.</remarks>
	internal static class FieldInfoProviderSingleton
	{
		#region Class Member Declarations
		private static readonly IFieldInfoProvider _providerInstance = new FieldInfoProviderCore();
		#endregion

		/// <summary>Dummy static constructor to make sure threadsafe initialization is performed.</summary>
		static FieldInfoProviderSingleton()
		{
		}

		/// <summary>Gets the singleton instance of the FieldInfoProviderCore</summary>
		/// <returns>Instance of the FieldInfoProvider.</returns>
		public static IFieldInfoProvider GetInstance()
		{
			return _providerInstance;
		}
	}

	/// <summary>Actual implementation of the FieldInfoProvider. Used by singleton wrapper.</summary>
	internal class FieldInfoProviderCore : FieldInfoProviderBase
	{
		/// <summary>Initializes a new instance of the <see cref="FieldInfoProviderCore"/> class.</summary>
		internal FieldInfoProviderCore()
		{
			Init();
		}

		/// <summary>Method which initializes the internal datastores.</summary>
		private void Init()
		{
			this.InitClass( (2 + 0));
			InitWebFunctionEntityInfos();
			InitWebRoleEntityInfos();

			this.ConstructElementFieldStructures(InheritanceInfoProviderSingleton.GetInstance());
		}

		/// <summary>Inits WebFunctionEntity's FieldInfo objects</summary>
		private void InitWebFunctionEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(WebFunctionFieldIndex), "WebFunctionEntity");
			this.AddElementFieldInfo("WebFunctionEntity", "DefaultApp", typeof(System.String), false, false, false, true,  (int)WebFunctionFieldIndex.DefaultApp, 20, 0, 0);
			this.AddElementFieldInfo("WebFunctionEntity", "DefaultParent", typeof(System.String), false, false, false, true,  (int)WebFunctionFieldIndex.DefaultParent, 20, 0, 0);
			this.AddElementFieldInfo("WebFunctionEntity", "DefaultSort", typeof(Nullable<System.Int16>), false, false, false, true,  (int)WebFunctionFieldIndex.DefaultSort, 0, 0, 4);
			this.AddElementFieldInfo("WebFunctionEntity", "DisableCode", typeof(Nullable<System.Int16>), false, false, false, true,  (int)WebFunctionFieldIndex.DisableCode, 0, 0, 3);
			this.AddElementFieldInfo("WebFunctionEntity", "DisableDate", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)WebFunctionFieldIndex.DisableDate, 0, 0, 0);
			this.AddElementFieldInfo("WebFunctionEntity", "FunctionAname", typeof(System.String), false, false, false, false,  (int)WebFunctionFieldIndex.FunctionAname, 100, 0, 0);
			this.AddElementFieldInfo("WebFunctionEntity", "FunctionEname", typeof(System.String), false, false, false, false,  (int)WebFunctionFieldIndex.FunctionEname, 100, 0, 0);
			this.AddElementFieldInfo("WebFunctionEntity", "FunctionId", typeof(System.String), true, false, false, false,  (int)WebFunctionFieldIndex.FunctionId, 20, 0, 0);
			this.AddElementFieldInfo("WebFunctionEntity", "FunctionUrl", typeof(System.String), false, false, false, true,  (int)WebFunctionFieldIndex.FunctionUrl, 200, 0, 0);
			this.AddElementFieldInfo("WebFunctionEntity", "Visible", typeof(System.Int16), false, false, false, false,  (int)WebFunctionFieldIndex.Visible, 0, 0, 1);
		}
		/// <summary>Inits WebRoleEntity's FieldInfo objects</summary>
		private void InitWebRoleEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(WebRoleFieldIndex), "WebRoleEntity");
			this.AddElementFieldInfo("WebRoleEntity", "DefaultFunction", typeof(System.String), false, false, false, true,  (int)WebRoleFieldIndex.DefaultFunction, 10, 0, 0);
			this.AddElementFieldInfo("WebRoleEntity", "DisableCode", typeof(Nullable<System.Int16>), false, false, false, true,  (int)WebRoleFieldIndex.DisableCode, 0, 0, 3);
			this.AddElementFieldInfo("WebRoleEntity", "DisableDate", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)WebRoleFieldIndex.DisableDate, 0, 0, 0);
			this.AddElementFieldInfo("WebRoleEntity", "RoleCode", typeof(System.String), true, false, false, false,  (int)WebRoleFieldIndex.RoleCode, 20, 0, 0);
			this.AddElementFieldInfo("WebRoleEntity", "RoleDesc", typeof(System.String), false, false, false, true,  (int)WebRoleFieldIndex.RoleDesc, 100, 0, 0);
		}
		
	}
}





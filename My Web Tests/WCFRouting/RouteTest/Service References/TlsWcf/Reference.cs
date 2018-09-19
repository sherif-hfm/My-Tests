﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RouteTest.TlsWcf {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="TlsWcf.ITLS")]
    public interface ITLS {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITLS/GetLicenseInfo", ReplyAction="http://tempuri.org/ITLS/GetLicenseInfoResponse")]
        Riyadh.EServices.Model.LicenseInfo GetLicenseInfo(int baladyaId, string licensesNo, int computerNo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITLS/GetLicenseInfo", ReplyAction="http://tempuri.org/ITLS/GetLicenseInfoResponse")]
        System.Threading.Tasks.Task<Riyadh.EServices.Model.LicenseInfo> GetLicenseInfoAsync(int baladyaId, string licensesNo, int computerNo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITLS/GetLicenseStoreInfo", ReplyAction="http://tempuri.org/ITLS/GetLicenseStoreInfoResponse")]
        Riyadh.EServices.Model.LicenseInfo[] GetLicenseStoreInfo(string ownerId, int ownerIdType, string licenseNo, string directorateNo, string computerNo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITLS/GetLicenseStoreInfo", ReplyAction="http://tempuri.org/ITLS/GetLicenseStoreInfoResponse")]
        System.Threading.Tasks.Task<Riyadh.EServices.Model.LicenseInfo[]> GetLicenseStoreInfoAsync(string ownerId, int ownerIdType, string licenseNo, string directorateNo, string computerNo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITLS/LicenseAllowedRenew", ReplyAction="http://tempuri.org/ITLS/LicenseAllowedRenewResponse")]
        Riyadh.EServices.Model.LicenseInfo LicenseAllowedRenew(int chargeCount, int licenseNo, int sadadType, string userCode, string webUser);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITLS/LicenseAllowedRenew", ReplyAction="http://tempuri.org/ITLS/LicenseAllowedRenewResponse")]
        System.Threading.Tasks.Task<Riyadh.EServices.Model.LicenseInfo> LicenseAllowedRenewAsync(int chargeCount, int licenseNo, int sadadType, string userCode, string webUser);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITLS/SendInspectorReport", ReplyAction="http://tempuri.org/ITLS/SendInspectorReportResponse")]
        int SendInspectorReport(string reportParmsXml);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITLS/SendInspectorReport", ReplyAction="http://tempuri.org/ITLS/SendInspectorReportResponse")]
        System.Threading.Tasks.Task<int> SendInspectorReportAsync(string reportParmsXml);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITLS/AddImageData", ReplyAction="http://tempuri.org/ITLS/AddImageDataResponse")]
        string AddImageData(int computerNo, int inspectionNo, string userCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITLS/AddImageData", ReplyAction="http://tempuri.org/ITLS/AddImageDataResponse")]
        System.Threading.Tasks.Task<string> AddImageDataAsync(int computerNo, int inspectionNo, string userCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITLS/GetLicenseMapPath", ReplyAction="http://tempuri.org/ITLS/GetLicenseMapPathResponse")]
        string GetLicenseMapPath(int licenseNo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITLS/GetLicenseMapPath", ReplyAction="http://tempuri.org/ITLS/GetLicenseMapPathResponse")]
        System.Threading.Tasks.Task<string> GetLicenseMapPathAsync(int licenseNo);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITLSChannel : RouteTest.TlsWcf.ITLS, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TLSClient : System.ServiceModel.ClientBase<RouteTest.TlsWcf.ITLS>, RouteTest.TlsWcf.ITLS {
        
        public TLSClient() {
        }
        
        public TLSClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TLSClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TLSClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TLSClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Riyadh.EServices.Model.LicenseInfo GetLicenseInfo(int baladyaId, string licensesNo, int computerNo) {
            return base.Channel.GetLicenseInfo(baladyaId, licensesNo, computerNo);
        }
        
        public System.Threading.Tasks.Task<Riyadh.EServices.Model.LicenseInfo> GetLicenseInfoAsync(int baladyaId, string licensesNo, int computerNo) {
            return base.Channel.GetLicenseInfoAsync(baladyaId, licensesNo, computerNo);
        }
        
        public Riyadh.EServices.Model.LicenseInfo[] GetLicenseStoreInfo(string ownerId, int ownerIdType, string licenseNo, string directorateNo, string computerNo) {
            return base.Channel.GetLicenseStoreInfo(ownerId, ownerIdType, licenseNo, directorateNo, computerNo);
        }
        
        public System.Threading.Tasks.Task<Riyadh.EServices.Model.LicenseInfo[]> GetLicenseStoreInfoAsync(string ownerId, int ownerIdType, string licenseNo, string directorateNo, string computerNo) {
            return base.Channel.GetLicenseStoreInfoAsync(ownerId, ownerIdType, licenseNo, directorateNo, computerNo);
        }
        
        public Riyadh.EServices.Model.LicenseInfo LicenseAllowedRenew(int chargeCount, int licenseNo, int sadadType, string userCode, string webUser) {
            return base.Channel.LicenseAllowedRenew(chargeCount, licenseNo, sadadType, userCode, webUser);
        }
        
        public System.Threading.Tasks.Task<Riyadh.EServices.Model.LicenseInfo> LicenseAllowedRenewAsync(int chargeCount, int licenseNo, int sadadType, string userCode, string webUser) {
            return base.Channel.LicenseAllowedRenewAsync(chargeCount, licenseNo, sadadType, userCode, webUser);
        }
        
        public int SendInspectorReport(string reportParmsXml) {
            return base.Channel.SendInspectorReport(reportParmsXml);
        }
        
        public System.Threading.Tasks.Task<int> SendInspectorReportAsync(string reportParmsXml) {
            return base.Channel.SendInspectorReportAsync(reportParmsXml);
        }
        
        public string AddImageData(int computerNo, int inspectionNo, string userCode) {
            return base.Channel.AddImageData(computerNo, inspectionNo, userCode);
        }
        
        public System.Threading.Tasks.Task<string> AddImageDataAsync(int computerNo, int inspectionNo, string userCode) {
            return base.Channel.AddImageDataAsync(computerNo, inspectionNo, userCode);
        }
        
        public string GetLicenseMapPath(int licenseNo) {
            return base.Channel.GetLicenseMapPath(licenseNo);
        }
        
        public System.Threading.Tasks.Task<string> GetLicenseMapPathAsync(int licenseNo) {
            return base.Channel.GetLicenseMapPathAsync(licenseNo);
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="TlsWcf.ITLSWeb")]
    public interface ITLSWeb {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITLSWeb/GetMalls", ReplyAction="http://tempuri.org/ITLSWeb/GetMallsResponse")]
        Riyadh.EServices.Model.MallInfo[] GetMalls(int _quarterNumber, int _streetNumber, int _realestateTypeCode, int _realestateClassification);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITLSWeb/GetMalls", ReplyAction="http://tempuri.org/ITLSWeb/GetMallsResponse")]
        System.Threading.Tasks.Task<Riyadh.EServices.Model.MallInfo[]> GetMallsAsync(int _quarterNumber, int _streetNumber, int _realestateTypeCode, int _realestateClassification);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITLSWeb/SaveTLSIssueRequest", ReplyAction="http://tempuri.org/ITLSWeb/SaveTLSIssueRequestResponse")]
        Riyadh.EServices.Model.TlsRequestSaveResult SaveTLSIssueRequest(Riyadh.EServices.Model.TLSRequest _issueRequest);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITLSWeb/SaveTLSIssueRequest", ReplyAction="http://tempuri.org/ITLSWeb/SaveTLSIssueRequestResponse")]
        System.Threading.Tasks.Task<Riyadh.EServices.Model.TlsRequestSaveResult> SaveTLSIssueRequestAsync(Riyadh.EServices.Model.TLSRequest _issueRequest);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITLSWeb/GetUserTradingLicenses", ReplyAction="http://tempuri.org/ITLSWeb/GetUserTradingLicensesResponse")]
        Riyadh.EServices.Model.LicenseInfo[] GetUserTradingLicenses(int userIdType, string userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITLSWeb/GetUserTradingLicenses", ReplyAction="http://tempuri.org/ITLSWeb/GetUserTradingLicensesResponse")]
        System.Threading.Tasks.Task<Riyadh.EServices.Model.LicenseInfo[]> GetUserTradingLicensesAsync(int userIdType, string userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITLSWeb/SaveRenewRequest", ReplyAction="http://tempuri.org/ITLSWeb/SaveRenewRequestResponse")]
        Riyadh.EServices.Model.TlsRequestSaveResult SaveRenewRequest(Riyadh.EServices.Model.TLSRequest _renewRequest);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITLSWeb/SaveRenewRequest", ReplyAction="http://tempuri.org/ITLSWeb/SaveRenewRequestResponse")]
        System.Threading.Tasks.Task<Riyadh.EServices.Model.TlsRequestSaveResult> SaveRenewRequestAsync(Riyadh.EServices.Model.TLSRequest _renewRequest);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITLSWeb/GetAllowServiceLicenses", ReplyAction="http://tempuri.org/ITLSWeb/GetAllowServiceLicensesResponse")]
        Riyadh.EServices.Model.LicenseInfo[] GetAllowServiceLicenses(int userIdType, string userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITLSWeb/GetAllowServiceLicenses", ReplyAction="http://tempuri.org/ITLSWeb/GetAllowServiceLicensesResponse")]
        System.Threading.Tasks.Task<Riyadh.EServices.Model.LicenseInfo[]> GetAllowServiceLicensesAsync(int userIdType, string userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITLSWeb/SaveTlsRequest", ReplyAction="http://tempuri.org/ITLSWeb/SaveTlsRequestResponse")]
        Riyadh.EServices.Model.TlsRequestSaveResult SaveTlsRequest(Riyadh.EServices.Model.TLSRequest _tlsRequest);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITLSWeb/SaveTlsRequest", ReplyAction="http://tempuri.org/ITLSWeb/SaveTlsRequestResponse")]
        System.Threading.Tasks.Task<Riyadh.EServices.Model.TlsRequestSaveResult> SaveTlsRequestAsync(Riyadh.EServices.Model.TLSRequest _tlsRequest);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITLSWeb/GetLicenseActivities", ReplyAction="http://tempuri.org/ITLSWeb/GetLicenseActivitiesResponse")]
        Riyadh.EServices.Model.LicenseActivity[] GetLicenseActivities(int _licenseNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITLSWeb/GetLicenseActivities", ReplyAction="http://tempuri.org/ITLSWeb/GetLicenseActivitiesResponse")]
        System.Threading.Tasks.Task<Riyadh.EServices.Model.LicenseActivity[]> GetLicenseActivitiesAsync(int _licenseNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITLSWeb/GetGlobalActivities", ReplyAction="http://tempuri.org/ITLSWeb/GetGlobalActivitiesResponse")]
        Riyadh.EServices.Model.LicenseActivityNode[] GetGlobalActivities();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITLSWeb/GetGlobalActivities", ReplyAction="http://tempuri.org/ITLSWeb/GetGlobalActivitiesResponse")]
        System.Threading.Tasks.Task<Riyadh.EServices.Model.LicenseActivityNode[]> GetGlobalActivitiesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITLSWeb/GetMainActivities", ReplyAction="http://tempuri.org/ITLSWeb/GetMainActivitiesResponse")]
        Riyadh.EServices.Model.LicenseActivityNode[] GetMainActivities(int _globalCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITLSWeb/GetMainActivities", ReplyAction="http://tempuri.org/ITLSWeb/GetMainActivitiesResponse")]
        System.Threading.Tasks.Task<Riyadh.EServices.Model.LicenseActivityNode[]> GetMainActivitiesAsync(int _globalCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITLSWeb/GetSubActivities", ReplyAction="http://tempuri.org/ITLSWeb/GetSubActivitiesResponse")]
        Riyadh.EServices.Model.LicenseActivityNode[] GetSubActivities(int _globalCode, int _subCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITLSWeb/GetSubActivities", ReplyAction="http://tempuri.org/ITLSWeb/GetSubActivitiesResponse")]
        System.Threading.Tasks.Task<Riyadh.EServices.Model.LicenseActivityNode[]> GetSubActivitiesAsync(int _globalCode, int _subCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITLSWeb/GetBoardsTypes", ReplyAction="http://tempuri.org/ITLSWeb/GetBoardsTypesResponse")]
        Riyadh.EServices.Model.LicenseBoard[] GetBoardsTypes();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITLSWeb/GetBoardsTypes", ReplyAction="http://tempuri.org/ITLSWeb/GetBoardsTypesResponse")]
        System.Threading.Tasks.Task<Riyadh.EServices.Model.LicenseBoard[]> GetBoardsTypesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITLSWeb/GetLicenseBoards", ReplyAction="http://tempuri.org/ITLSWeb/GetLicenseBoardsResponse")]
        Riyadh.EServices.Model.LicenseBoard[] GetLicenseBoards(int _licenseNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITLSWeb/GetLicenseBoards", ReplyAction="http://tempuri.org/ITLSWeb/GetLicenseBoardsResponse")]
        System.Threading.Tasks.Task<Riyadh.EServices.Model.LicenseBoard[]> GetLicenseBoardsAsync(int _licenseNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITLSWeb/GetActivitiesConditions", ReplyAction="http://tempuri.org/ITLSWeb/GetActivitiesConditionsResponse")]
        Riyadh.EServices.Model.ActivitiesConditionsInfo[] GetActivitiesConditions(System.Nullable<int> globalCode, System.Nullable<int> mainCode, System.Nullable<int> subCode, System.Nullable<int> conditionTypeCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITLSWeb/GetActivitiesConditions", ReplyAction="http://tempuri.org/ITLSWeb/GetActivitiesConditionsResponse")]
        System.Threading.Tasks.Task<Riyadh.EServices.Model.ActivitiesConditionsInfo[]> GetActivitiesConditionsAsync(System.Nullable<int> globalCode, System.Nullable<int> mainCode, System.Nullable<int> subCode, System.Nullable<int> conditionTypeCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITLSWeb/GetActivitiesConditionsNew", ReplyAction="http://tempuri.org/ITLSWeb/GetActivitiesConditionsNewResponse")]
        Riyadh.EServices.Model.ActivitiesConditionsInfo[] GetActivitiesConditionsNew(System.Nullable<int> globalCode, System.Nullable<int> mainCode, System.Nullable<int> subCode, System.Nullable<int> conditionTypeCode, System.Nullable<int> issueRequired, System.Nullable<int> renewRequired, System.Nullable<int> cancelRequired);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITLSWeb/GetActivitiesConditionsNew", ReplyAction="http://tempuri.org/ITLSWeb/GetActivitiesConditionsNewResponse")]
        System.Threading.Tasks.Task<Riyadh.EServices.Model.ActivitiesConditionsInfo[]> GetActivitiesConditionsNewAsync(System.Nullable<int> globalCode, System.Nullable<int> mainCode, System.Nullable<int> subCode, System.Nullable<int> conditionTypeCode, System.Nullable<int> issueRequired, System.Nullable<int> renewRequired, System.Nullable<int> cancelRequired);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITLSWeb/GetMainType", ReplyAction="http://tempuri.org/ITLSWeb/GetMainTypeResponse")]
        Riyadh.EServices.Model.LicenseActivityNode GetMainType(System.Nullable<int> globalCode, System.Nullable<int> mainCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITLSWeb/GetMainType", ReplyAction="http://tempuri.org/ITLSWeb/GetMainTypeResponse")]
        System.Threading.Tasks.Task<Riyadh.EServices.Model.LicenseActivityNode> GetMainTypeAsync(System.Nullable<int> globalCode, System.Nullable<int> mainCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITLSWeb/GetActivitiesApprovals", ReplyAction="http://tempuri.org/ITLSWeb/GetActivitiesApprovalsResponse")]
        Riyadh.EServices.Model.ActivitiesApprovals[] GetActivitiesApprovals(System.Nullable<int> globalCode, System.Nullable<int> mainCode, System.Nullable<int> subCode, System.Nullable<int> issueRequired, System.Nullable<int> renewRequired, System.Nullable<int> cancelRequired);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITLSWeb/GetActivitiesApprovals", ReplyAction="http://tempuri.org/ITLSWeb/GetActivitiesApprovalsResponse")]
        System.Threading.Tasks.Task<Riyadh.EServices.Model.ActivitiesApprovals[]> GetActivitiesApprovalsAsync(System.Nullable<int> globalCode, System.Nullable<int> mainCode, System.Nullable<int> subCode, System.Nullable<int> issueRequired, System.Nullable<int> renewRequired, System.Nullable<int> cancelRequired);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITLSWeb/GetAcivitiesDocuments", ReplyAction="http://tempuri.org/ITLSWeb/GetAcivitiesDocumentsResponse")]
        Riyadh.EServices.Model.AcivitiesDocuments[] GetAcivitiesDocuments(System.Nullable<int> globalCode, System.Nullable<int> mainCode, System.Nullable<int> subCode, System.Nullable<int> issueRequired, System.Nullable<int> renewRequired, System.Nullable<int> cancelRequired);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITLSWeb/GetAcivitiesDocuments", ReplyAction="http://tempuri.org/ITLSWeb/GetAcivitiesDocumentsResponse")]
        System.Threading.Tasks.Task<Riyadh.EServices.Model.AcivitiesDocuments[]> GetAcivitiesDocumentsAsync(System.Nullable<int> globalCode, System.Nullable<int> mainCode, System.Nullable<int> subCode, System.Nullable<int> issueRequired, System.Nullable<int> renewRequired, System.Nullable<int> cancelRequired);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITLSWeb/GetTlsAuthorities", ReplyAction="http://tempuri.org/ITLSWeb/GetTlsAuthoritiesResponse")]
        Riyadh.EServices.Model.BaseInfo[] GetTlsAuthorities();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITLSWeb/GetTlsAuthorities", ReplyAction="http://tempuri.org/ITLSWeb/GetTlsAuthoritiesResponse")]
        System.Threading.Tasks.Task<Riyadh.EServices.Model.BaseInfo[]> GetTlsAuthoritiesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITLSWeb/GetRenewDisableReason", ReplyAction="http://tempuri.org/ITLSWeb/GetRenewDisableReasonResponse")]
        Riyadh.EServices.Model.ServicesSatatusInfo GetRenewDisableReason(decimal licenceNo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITLSWeb/GetRenewDisableReason", ReplyAction="http://tempuri.org/ITLSWeb/GetRenewDisableReasonResponse")]
        System.Threading.Tasks.Task<Riyadh.EServices.Model.ServicesSatatusInfo> GetRenewDisableReasonAsync(decimal licenceNo);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITLSWebChannel : RouteTest.TlsWcf.ITLSWeb, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TLSWebClient : System.ServiceModel.ClientBase<RouteTest.TlsWcf.ITLSWeb>, RouteTest.TlsWcf.ITLSWeb {
        
        public TLSWebClient() {
        }
        
        public TLSWebClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TLSWebClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TLSWebClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TLSWebClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Riyadh.EServices.Model.MallInfo[] GetMalls(int _quarterNumber, int _streetNumber, int _realestateTypeCode, int _realestateClassification) {
            return base.Channel.GetMalls(_quarterNumber, _streetNumber, _realestateTypeCode, _realestateClassification);
        }
        
        public System.Threading.Tasks.Task<Riyadh.EServices.Model.MallInfo[]> GetMallsAsync(int _quarterNumber, int _streetNumber, int _realestateTypeCode, int _realestateClassification) {
            return base.Channel.GetMallsAsync(_quarterNumber, _streetNumber, _realestateTypeCode, _realestateClassification);
        }
        
        public Riyadh.EServices.Model.TlsRequestSaveResult SaveTLSIssueRequest(Riyadh.EServices.Model.TLSRequest _issueRequest) {
            return base.Channel.SaveTLSIssueRequest(_issueRequest);
        }
        
        public System.Threading.Tasks.Task<Riyadh.EServices.Model.TlsRequestSaveResult> SaveTLSIssueRequestAsync(Riyadh.EServices.Model.TLSRequest _issueRequest) {
            return base.Channel.SaveTLSIssueRequestAsync(_issueRequest);
        }
        
        public Riyadh.EServices.Model.LicenseInfo[] GetUserTradingLicenses(int userIdType, string userId) {
            return base.Channel.GetUserTradingLicenses(userIdType, userId);
        }
        
        public System.Threading.Tasks.Task<Riyadh.EServices.Model.LicenseInfo[]> GetUserTradingLicensesAsync(int userIdType, string userId) {
            return base.Channel.GetUserTradingLicensesAsync(userIdType, userId);
        }
        
        public Riyadh.EServices.Model.TlsRequestSaveResult SaveRenewRequest(Riyadh.EServices.Model.TLSRequest _renewRequest) {
            return base.Channel.SaveRenewRequest(_renewRequest);
        }
        
        public System.Threading.Tasks.Task<Riyadh.EServices.Model.TlsRequestSaveResult> SaveRenewRequestAsync(Riyadh.EServices.Model.TLSRequest _renewRequest) {
            return base.Channel.SaveRenewRequestAsync(_renewRequest);
        }
        
        public Riyadh.EServices.Model.LicenseInfo[] GetAllowServiceLicenses(int userIdType, string userId) {
            return base.Channel.GetAllowServiceLicenses(userIdType, userId);
        }
        
        public System.Threading.Tasks.Task<Riyadh.EServices.Model.LicenseInfo[]> GetAllowServiceLicensesAsync(int userIdType, string userId) {
            return base.Channel.GetAllowServiceLicensesAsync(userIdType, userId);
        }
        
        public Riyadh.EServices.Model.TlsRequestSaveResult SaveTlsRequest(Riyadh.EServices.Model.TLSRequest _tlsRequest) {
            return base.Channel.SaveTlsRequest(_tlsRequest);
        }
        
        public System.Threading.Tasks.Task<Riyadh.EServices.Model.TlsRequestSaveResult> SaveTlsRequestAsync(Riyadh.EServices.Model.TLSRequest _tlsRequest) {
            return base.Channel.SaveTlsRequestAsync(_tlsRequest);
        }
        
        public Riyadh.EServices.Model.LicenseActivity[] GetLicenseActivities(int _licenseNumber) {
            return base.Channel.GetLicenseActivities(_licenseNumber);
        }
        
        public System.Threading.Tasks.Task<Riyadh.EServices.Model.LicenseActivity[]> GetLicenseActivitiesAsync(int _licenseNumber) {
            return base.Channel.GetLicenseActivitiesAsync(_licenseNumber);
        }
        
        public Riyadh.EServices.Model.LicenseActivityNode[] GetGlobalActivities() {
            return base.Channel.GetGlobalActivities();
        }
        
        public System.Threading.Tasks.Task<Riyadh.EServices.Model.LicenseActivityNode[]> GetGlobalActivitiesAsync() {
            return base.Channel.GetGlobalActivitiesAsync();
        }
        
        public Riyadh.EServices.Model.LicenseActivityNode[] GetMainActivities(int _globalCode) {
            return base.Channel.GetMainActivities(_globalCode);
        }
        
        public System.Threading.Tasks.Task<Riyadh.EServices.Model.LicenseActivityNode[]> GetMainActivitiesAsync(int _globalCode) {
            return base.Channel.GetMainActivitiesAsync(_globalCode);
        }
        
        public Riyadh.EServices.Model.LicenseActivityNode[] GetSubActivities(int _globalCode, int _subCode) {
            return base.Channel.GetSubActivities(_globalCode, _subCode);
        }
        
        public System.Threading.Tasks.Task<Riyadh.EServices.Model.LicenseActivityNode[]> GetSubActivitiesAsync(int _globalCode, int _subCode) {
            return base.Channel.GetSubActivitiesAsync(_globalCode, _subCode);
        }
        
        public Riyadh.EServices.Model.LicenseBoard[] GetBoardsTypes() {
            return base.Channel.GetBoardsTypes();
        }
        
        public System.Threading.Tasks.Task<Riyadh.EServices.Model.LicenseBoard[]> GetBoardsTypesAsync() {
            return base.Channel.GetBoardsTypesAsync();
        }
        
        public Riyadh.EServices.Model.LicenseBoard[] GetLicenseBoards(int _licenseNumber) {
            return base.Channel.GetLicenseBoards(_licenseNumber);
        }
        
        public System.Threading.Tasks.Task<Riyadh.EServices.Model.LicenseBoard[]> GetLicenseBoardsAsync(int _licenseNumber) {
            return base.Channel.GetLicenseBoardsAsync(_licenseNumber);
        }
        
        public Riyadh.EServices.Model.ActivitiesConditionsInfo[] GetActivitiesConditions(System.Nullable<int> globalCode, System.Nullable<int> mainCode, System.Nullable<int> subCode, System.Nullable<int> conditionTypeCode) {
            return base.Channel.GetActivitiesConditions(globalCode, mainCode, subCode, conditionTypeCode);
        }
        
        public System.Threading.Tasks.Task<Riyadh.EServices.Model.ActivitiesConditionsInfo[]> GetActivitiesConditionsAsync(System.Nullable<int> globalCode, System.Nullable<int> mainCode, System.Nullable<int> subCode, System.Nullable<int> conditionTypeCode) {
            return base.Channel.GetActivitiesConditionsAsync(globalCode, mainCode, subCode, conditionTypeCode);
        }
        
        public Riyadh.EServices.Model.ActivitiesConditionsInfo[] GetActivitiesConditionsNew(System.Nullable<int> globalCode, System.Nullable<int> mainCode, System.Nullable<int> subCode, System.Nullable<int> conditionTypeCode, System.Nullable<int> issueRequired, System.Nullable<int> renewRequired, System.Nullable<int> cancelRequired) {
            return base.Channel.GetActivitiesConditionsNew(globalCode, mainCode, subCode, conditionTypeCode, issueRequired, renewRequired, cancelRequired);
        }
        
        public System.Threading.Tasks.Task<Riyadh.EServices.Model.ActivitiesConditionsInfo[]> GetActivitiesConditionsNewAsync(System.Nullable<int> globalCode, System.Nullable<int> mainCode, System.Nullable<int> subCode, System.Nullable<int> conditionTypeCode, System.Nullable<int> issueRequired, System.Nullable<int> renewRequired, System.Nullable<int> cancelRequired) {
            return base.Channel.GetActivitiesConditionsNewAsync(globalCode, mainCode, subCode, conditionTypeCode, issueRequired, renewRequired, cancelRequired);
        }
        
        public Riyadh.EServices.Model.LicenseActivityNode GetMainType(System.Nullable<int> globalCode, System.Nullable<int> mainCode) {
            return base.Channel.GetMainType(globalCode, mainCode);
        }
        
        public System.Threading.Tasks.Task<Riyadh.EServices.Model.LicenseActivityNode> GetMainTypeAsync(System.Nullable<int> globalCode, System.Nullable<int> mainCode) {
            return base.Channel.GetMainTypeAsync(globalCode, mainCode);
        }
        
        public Riyadh.EServices.Model.ActivitiesApprovals[] GetActivitiesApprovals(System.Nullable<int> globalCode, System.Nullable<int> mainCode, System.Nullable<int> subCode, System.Nullable<int> issueRequired, System.Nullable<int> renewRequired, System.Nullable<int> cancelRequired) {
            return base.Channel.GetActivitiesApprovals(globalCode, mainCode, subCode, issueRequired, renewRequired, cancelRequired);
        }
        
        public System.Threading.Tasks.Task<Riyadh.EServices.Model.ActivitiesApprovals[]> GetActivitiesApprovalsAsync(System.Nullable<int> globalCode, System.Nullable<int> mainCode, System.Nullable<int> subCode, System.Nullable<int> issueRequired, System.Nullable<int> renewRequired, System.Nullable<int> cancelRequired) {
            return base.Channel.GetActivitiesApprovalsAsync(globalCode, mainCode, subCode, issueRequired, renewRequired, cancelRequired);
        }
        
        public Riyadh.EServices.Model.AcivitiesDocuments[] GetAcivitiesDocuments(System.Nullable<int> globalCode, System.Nullable<int> mainCode, System.Nullable<int> subCode, System.Nullable<int> issueRequired, System.Nullable<int> renewRequired, System.Nullable<int> cancelRequired) {
            return base.Channel.GetAcivitiesDocuments(globalCode, mainCode, subCode, issueRequired, renewRequired, cancelRequired);
        }
        
        public System.Threading.Tasks.Task<Riyadh.EServices.Model.AcivitiesDocuments[]> GetAcivitiesDocumentsAsync(System.Nullable<int> globalCode, System.Nullable<int> mainCode, System.Nullable<int> subCode, System.Nullable<int> issueRequired, System.Nullable<int> renewRequired, System.Nullable<int> cancelRequired) {
            return base.Channel.GetAcivitiesDocumentsAsync(globalCode, mainCode, subCode, issueRequired, renewRequired, cancelRequired);
        }
        
        public Riyadh.EServices.Model.BaseInfo[] GetTlsAuthorities() {
            return base.Channel.GetTlsAuthorities();
        }
        
        public System.Threading.Tasks.Task<Riyadh.EServices.Model.BaseInfo[]> GetTlsAuthoritiesAsync() {
            return base.Channel.GetTlsAuthoritiesAsync();
        }
        
        public Riyadh.EServices.Model.ServicesSatatusInfo GetRenewDisableReason(decimal licenceNo) {
            return base.Channel.GetRenewDisableReason(licenceNo);
        }
        
        public System.Threading.Tasks.Task<Riyadh.EServices.Model.ServicesSatatusInfo> GetRenewDisableReasonAsync(decimal licenceNo) {
            return base.Channel.GetRenewDisableReasonAsync(licenceNo);
        }
    }
}

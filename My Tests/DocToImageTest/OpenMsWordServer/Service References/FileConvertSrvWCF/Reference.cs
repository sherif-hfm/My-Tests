﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OpenMsWordServer.FileConvertSrvWCF {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="FileConvertSrvWCF.IFileConvertSrv")]
    public interface IFileConvertSrv {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFileConvertSrv/DocToImageConvert", ReplyAction="http://tempuri.org/IFileConvertSrv/DocToImageConvertResponse")]
        byte[] DocToImageConvert(byte[] _docData);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFileConvertSrv/DocToImageConvert", ReplyAction="http://tempuri.org/IFileConvertSrv/DocToImageConvertResponse")]
        System.Threading.Tasks.Task<byte[]> DocToImageConvertAsync(byte[] _docData);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IFileConvertSrvChannel : OpenMsWordServer.FileConvertSrvWCF.IFileConvertSrv, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class FileConvertSrvClient : System.ServiceModel.ClientBase<OpenMsWordServer.FileConvertSrvWCF.IFileConvertSrv>, OpenMsWordServer.FileConvertSrvWCF.IFileConvertSrv {
        
        public FileConvertSrvClient() {
        }
        
        public FileConvertSrvClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public FileConvertSrvClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FileConvertSrvClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FileConvertSrvClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public byte[] DocToImageConvert(byte[] _docData) {
            return base.Channel.DocToImageConvert(_docData);
        }
        
        public System.Threading.Tasks.Task<byte[]> DocToImageConvertAsync(byte[] _docData) {
            return base.Channel.DocToImageConvertAsync(_docData);
        }
    }
}

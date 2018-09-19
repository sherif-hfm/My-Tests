using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfJson
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    
    public interface IService1
    {
        [OperationContract]
        //[WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [WebInvoke(Method = "GET",  RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        //[WebInvoke(Method = "GET")]
        GetIdentityTypeResponse GetIdentityTypes();
        
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    
    [DataContract]
    public class IdentityType
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }
    }

    [DataContract]
    public class GetIdentityTypeResponse
    {
        [DataMember]
        public List<IdentityType> ResultItem { get; set; }

        [DataMember]
        public int StatusCode { get; set; }

        [DataMember]
        public string StatusName { get; set; }

        [DataMember]
        public string ErrorDetails { get; set; }

        [DataMember]
        public string MunicipalityId { get; set; }
    }
}

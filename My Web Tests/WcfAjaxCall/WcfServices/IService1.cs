using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        UserData GetUserData(UserData userData);
        
    }

    [DataContract]
    public class UserData
    {
        [DataMember]
        public string UserName {get;set;}
       
        [DataMember]
        public decimal UserAge { get; set; }

        [DataMember]
        public string UserImage { get; set; }

        [DataMember]
        public List<Address> UserAddress { get; set; }
    }

    [DataContract]
    public class Address
    {
        [DataMember]
        public string Town { get; set; }

        [DataMember]
        public string Street { get; set; }

        [DataMember]
        public string PoBox { get; set; }
    }
}

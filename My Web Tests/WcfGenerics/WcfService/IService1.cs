using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        ServiceResult<PersonInfo> GetData(string _personId);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class  ServiceResult<T>
    {
        [DataMember]
        public bool Status { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public T Result { get; set; }
    }

    [DataContract]
    public class PersonInfo
    {
        [DataMember]
        public string PersonId { get; set; }

        [DataMember]
        public string PersonName { get; set; }
    }
}

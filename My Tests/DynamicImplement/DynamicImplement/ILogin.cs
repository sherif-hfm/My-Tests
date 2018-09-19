using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace DynamicImplement
{
    [ServiceContract]
    public interface ILogin
    {
        [OperationContract]
        [WebInvoke(Method = "GET")]
        string DoLogin(string UserName,string Password);
    }
}

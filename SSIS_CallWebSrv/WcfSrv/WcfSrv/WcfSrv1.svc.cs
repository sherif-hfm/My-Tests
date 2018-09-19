using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfSrv
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class WcfSrv1 : IWcfSrv1
    {
        public string SendData(string _data, string _branchId)
        {
            var id = Guid.NewGuid().ToString();
            File.WriteAllText(@"D:\Dropbox\My Tests\SSIS_CallWebSrv\XmlData\data_" + _branchId + "_" + id + ".xml", _data);
            return "OK";
        }
       
    }
}

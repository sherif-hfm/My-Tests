using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicImplement
{
    public class LoggerDynamicProxy : DynamicProxy
    {

        protected override bool TryInvokeMember(Type interfaceType, string name, object[] args, out object result)
        {
            result = "DoLogin OK";
            return true;
        }
    }
}

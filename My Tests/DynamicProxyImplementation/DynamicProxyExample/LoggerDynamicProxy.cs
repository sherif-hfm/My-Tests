using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicProxyImplementation;

namespace DynamicProxyExample
{
    public class LoggerDynamicProxy : DynamicProxy
    {
        protected override bool TryInvokeMember(Type interfaceType, string name, object[] args, out object result)
        {
            System.Console.WriteLine(string.Format("Method invoked. Interface type: {0}. Method name: {1}. Arguments: {2}.", interfaceType.Name, name, string.Join(",", args)));
            result = null;
            return true;
        }

        protected override bool TrySetMember(Type interfaceType, string name, object value)
        {
            System.Console.WriteLine(string.Format("Set property. Interface type: {0}. Member name: {1}. Value: {2}.", interfaceType.Name, name, value));
            return true;
        }

        protected override bool TryGetMember(Type interfaceType, string name, out object result)
        {
            System.Console.WriteLine(string.Format("Get property. Interface type: {0}. Property name: {1}.", interfaceType.Name, name));
            result = null;
            return true;
        }

        protected override bool TrySetEvent(Type interfaceType, string name, object value)
        {
            System.Console.WriteLine(string.Format("Set event. Interface type: {0}. Member name: {1}. Value: {2}.", interfaceType.Name, name, value));
            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicImplement
{
    public class  AppDynamicClass : DynamicObject 
    {
        private Type _type;
        public AppDynamicClass(Type t)
        {
            _type = t;
        }
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            var method = _type.GetMethod(binder.Name);
            var prms = method.GetParameters();
            var attrs = method.GetCustomAttributes(true);
            result = "";
            return true;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            return true;
        }
    }
}

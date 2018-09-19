using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DynamicImplement
{
    public abstract class DynamicProxy : IDisposable
    {

        private static object dummyOut;
        public static MethodInfo TryInvokeMemberMethodInfo = ExpressionHelper.GetMethodCallExpressionMethodInfo<DynamicProxy>(o => o.TryInvokeMember(null, null, null, out dummyOut));

        protected DynamicProxy()
        {
        }

        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
        }
        protected abstract bool TryInvokeMember(Type interfaceType, string name, object[] args, out object result);
      

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicProxyImplementation;

namespace DynamicProxyExample
{
    public static class TestDIContainer
    {
        private static Dictionary<Type, Func<object>> diFuncs = new Dictionary<Type, Func<object>>();

        private static DynamicProxyFactory<QueueDynamicProxy> factory = new DynamicProxyFactory<QueueDynamicProxy>(new DynamicInterfaceImplementor());

        public static event EventHandler NewTypeRegistered;

        public static void RegisterFunc(Type t, Func<object> createFunc)
        {
            diFuncs.Add(t, createFunc);
            OnNewTypeRegistered();
        }

        private static void OnNewTypeRegistered()
        {
            if (NewTypeRegistered != null)
            {
                NewTypeRegistered(null, EventArgs.Empty);
            }
        }

        public static bool HasRealImplementation(Type t)
        {
            bool ret;
            ret = diFuncs.ContainsKey(t);
            return ret;
        }


        public static object GetInstance(Type t)
        {
            object ret;
            Func<object> f;
            if (diFuncs.TryGetValue(t, out f))
            {
                ret = f();
            }
            else
            {
                ret = factory.CreateDynamicProxy(t, t);
            }
            return ret;
        }
    }
}

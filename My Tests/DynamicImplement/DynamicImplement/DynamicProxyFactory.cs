using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicImplement
{
    public class DynamicProxyFactory<TDynamicProxyType> : IDynamicProxyFactory where TDynamicProxyType : DynamicProxy
    {
        private IDynamicInterfaceImplementor interfaceImplementor = null;
        public DynamicProxyFactory(IDynamicInterfaceImplementor interfaceImplementor)
        {
            this.interfaceImplementor = interfaceImplementor;
        }

        public virtual TInterfaceType CreateDynamicProxy<TInterfaceType>(params object[] constructorParameters)
        {
            TInterfaceType ret;

            ret = (TInterfaceType)CreateDynamicProxy(typeof(TInterfaceType), constructorParameters);

            return ret;
        }

        public virtual object CreateDynamicProxy(Type interfaceType, params object[] constructorParameters)
        {

            object ret = null;

            Type t = interfaceImplementor.CreateType(interfaceType, typeof(TDynamicProxyType));
            ret = Activator.CreateInstance(t, constructorParameters);

            return ret;
        }
    }
}

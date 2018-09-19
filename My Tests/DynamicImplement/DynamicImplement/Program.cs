using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicImplement
{
    class Program
    {
        static void Main(string[] args)
        {
            //DoDynamicImplement();
            DoDynamicClass();
        }

        private static void DoDynamicImplement()
        {
            DynamicProxyFactory<LoggerDynamicProxy> factory = new DynamicProxyFactory<LoggerDynamicProxy>(new DynamicInterfaceImplementor());
            ILogin login = factory.CreateDynamicProxy<ILogin>();
            //var result = login.DoLogin();
        }

        private static void DoDynamicClass()
        {
            dynamic obj = new AppDynamicClass(typeof(ILogin));
            //obj.DoLogin();
            obj.DoLogin(UserName : "UserNameData", Password : "PasswordData");
        }
    }
}

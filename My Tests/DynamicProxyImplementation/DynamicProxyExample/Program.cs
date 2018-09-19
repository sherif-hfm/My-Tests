using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicProxyImplementation;

namespace DynamicProxyExample
{
    class Program
    {
        static void Main(string[] args)
        {
            LoggerDynamicProxyTest();
            //QueueDynamicProxyTest();
        }

        private static void LoggerDynamicProxyTest()
        {
            Console.WriteLine("-------LoggerDynamicProxyTest start-------");
            DynamicProxyFactory<LoggerDynamicProxy> factory = new DynamicProxyFactory<LoggerDynamicProxy>(new DynamicInterfaceImplementor());
            ILogin login = factory.CreateDynamicProxy<ILogin>();
            login.LoginName = "test";
            login.Password = "password";
            var asd = login.LoginName;
            login.TryLogin += login_TryLogin;
            login.DoLogin();
            Console.WriteLine("-------LoggerDynamicProxyTest end-------");
            Console.ReadLine();
        }

        private static void QueueDynamicProxyTest()
        {
            Console.WriteLine("-------QueueDynamicProxyTest start-------");
            ILogin login = (ILogin)TestDIContainer.GetInstance(typeof(ILogin));
            login.LoginName = "test";
            login.Password = "password";
            login.TryLogin += login_TryLogin;
            login.DoLogin();
            Console.WriteLine("Press any key to register real implementation!");
            Console.ReadLine();
            TestDIContainer.RegisterFunc(typeof(ILogin), () => { return new Login(); });
            Console.WriteLine("-------QueueDynamicProxyTest end-------");
            Console.ReadLine();
        }

        private static void login_TryLogin(object sender, EventArgs e)
        {
            //Do login
            System.Console.WriteLine("login_TryLogin");

        }
    }
}

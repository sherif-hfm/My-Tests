using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                WebService1.UserName user = new WebService1.UserName() { Text = new string[1] { "user" } };
                WebService1.Password pass = new WebService1.Password() { Text = new string[1] { "password" } };

                WebService1.WebService1 srv = new WebService1.WebService1();
                srv.UserNameValue = user;
                srv.PasswordValue = pass;
                srv.HelloWorld("asd");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

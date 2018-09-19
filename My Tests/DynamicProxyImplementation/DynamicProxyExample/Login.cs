using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProxyExample
{
    public class Login : ILogin
    {
        private string loginName = null;
        public string LoginName
        {
            get
            {
                System.Console.WriteLine("Get LoginName: " + loginName);
                return loginName;
            }
            set
            {
                System.Console.WriteLine("Set LoginName to: " + value);
                loginName = value;
            }
        }

        private string password = null;
        public string Password
        {
            get
            {
                System.Console.WriteLine("Get Password: " + password);
                return password;
            }
            set
            {
                System.Console.WriteLine("Set Password to: " + value);
                password = value;
            }
        }

        public void DoLogin()
        {
            System.Console.WriteLine("DoLogin invoked!");
            if (TryLogin != null)
            {
                TryLogin(this, EventArgs.Empty);
            }
        }

        public event EventHandler TryLogin;
    }
}

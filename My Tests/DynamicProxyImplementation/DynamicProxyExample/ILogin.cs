using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProxyExample
{
    public interface ILogin
    {
        string LoginName { get; set; }
        string Password { get; set; }
        void DoLogin();
        event EventHandler TryLogin;
    }
}

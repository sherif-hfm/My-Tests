using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5Security.Customization
{
    public class IdentityUser : IUser<int>
    {
        public int Id
        {
            get { throw new NotImplementedException(); }
        }

        public string UserName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
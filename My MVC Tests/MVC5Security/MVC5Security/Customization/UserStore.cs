using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5Security.Customization
{
    public class UserStore : IUserStore<IdentityUser, int>
    {
        public System.Threading.Tasks.Task CreateAsync(IdentityUser user)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task DeleteAsync(IdentityUser user)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<IdentityUser> FindByIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<IdentityUser> FindByNameAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task UpdateAsync(IdentityUser user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace AuthorizationServer
{
    public class ApplicationUser : IUser<int>
    {
        public ApplicationUser()
        {
            this.Roles = new List<string>();
            this.Claims = new List<UserClaim>();
            this.Logins = new List<UserLoginInfo>();
        }

        public ApplicationUser(string userName)
            : this()
        {
            this.UserName = userName;
        }

        public ApplicationUser(int id, string userName) : this()
        {
            this.Id = id;
            this.UserName = userName;
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }

        public bool LockoutEnabled { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public bool TwoFactorEnabled { get; set; }

        public IList<string> Roles { get; private set; }
        public IList<UserClaim> Claims { get; private set; }
        public List<UserLoginInfo> Logins { get; private set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(AppUserManager manager, string authenticationType)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            userIdentity.AddClaim(new Claim(ClaimTypes.Role, "Admin"));
            // Add custom user claims here
            return userIdentity;
        }
    }
}
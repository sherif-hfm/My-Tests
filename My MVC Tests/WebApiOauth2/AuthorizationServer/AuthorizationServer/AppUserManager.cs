using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
namespace AuthorizationServer
{
    public class AppUserManager : UserManager<ApplicationUser, int>
    {
        public AppUserManager(IUserStore<ApplicationUser, int> store) : base(store)
        {
            this.UserLockoutEnabledByDefault = false;
            // this.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(10);
            // this.MaxFailedAccessAttemptsBeforeLockout = 10;
            this.UserValidator = new UserValidator<ApplicationUser, int>(this)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = false
            };

            // Configure validation logic for passwords
            this.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 4,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

        }

        public static AppUserManager Create()
        {
            UserStore userStore = new UserStore();
            var appUserManager = new AppUserManager(userStore);
            return appUserManager;
        }

    }
}
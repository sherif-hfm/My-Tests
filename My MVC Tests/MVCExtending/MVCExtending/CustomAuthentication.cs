using System;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace MVCExtending
{
    public class CustomAuthenticationAttribute : FilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            filterContext.Result = new HttpStatusCodeResult(401, "Invalid Authorization");
            //IPrincipal principal = Authenticate();
            //filterContext.Principal = principal;
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            
        }
        

        private IPrincipal Authenticate()
        {
            // For this sample, there is one password that works with any user ID.
            // All other passwords are invalid.
           

            // For this sample, a user only has a name (the user ID provided in the Basic credentials).
            Claim[] claims = new Claim[] { new Claim(ClaimTypes.Name, "") };
            return new ClaimsPrincipal(new ClaimsIdentity(claims, "Basic"));
        }
    }
}
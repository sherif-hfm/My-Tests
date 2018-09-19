using System;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace MVCExtending.Areas.BasicAuthenticationFilter.Utility
{
    public class BasicAuthenticationAttribute : FilterAttribute, IAuthenticationFilter
    {
        public string Password { get; set; }

        public void OnAuthentication(AuthenticationContext filterContext)
        {
            // An authentication filter can have on of three outcomes for the OnAuthentication method:
            // 1. Authentication was not attempted. In this case, do not set either Principal or Result.
            // 2. Authentication was attempted but failed. In this case, set the Result property to indicate failure.
            // 3. Authentication was attempted and succeeded. In this case, set the Principal property to indicate success.

            string authorization = filterContext.HttpContext.Request.Headers["Authorization"];

            if (authorization == null || !authorization.StartsWith("Basic "))
            {
                // The request does not contain a Basic authorization header.
                // No authentication was attempted for this filter (do not set either Principal or Result).
                return;
            }

            // Get the base64-encoded username and password
            string parameter = authorization.Substring("Basic ".Length).TrimStart(' ');

            // Convert 
            byte[] decoded;

            try
            {
                decoded = Convert.FromBase64String(parameter);
            }
            catch (FormatException)
            {
                // The request contains a Basic authorization header, but it does not have a valid Base64-encoded parameter.
                // Authentication was attempted but failed (set Result, not Principal).
                filterContext.Result = new HttpStatusCodeResult(400, "Invalid Basic Authorization Base64");
                return;
            }

            string userIdColonPassword;

            Encoding encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: true);

            try
            {
                userIdColonPassword = encoding.GetString(decoded);
            }
            catch (DecoderFallbackException)
            {
                // The request contains a Basic authorization header, but it does not have a valid Base64-encoded data.
                // Authentication was attempted but failed (set Result, not Principal).
                filterContext.Result = new HttpStatusCodeResult(400, "Invalid Basic Authorization UTF8");
                return;
            }

            int colonIndex = userIdColonPassword != null ? userIdColonPassword.IndexOf(':') : -1;

            if (colonIndex == -1)
            {
                // The request contains a Basic authorization header, but it is not in username:password format.
                // Authentication was attempted but failed (set Result, not Principal).
                filterContext.Result = new HttpStatusCodeResult(400, "Invalid Basic Authorization Credentials");
                return;
            }

            string userId = userIdColonPassword.Substring(0, colonIndex);
            string password = userIdColonPassword.Substring(colonIndex + 1);

            IPrincipal principal = Authenticate(userId, password);

            if (principal == null)
            {
                // The request contains a Basic authentication header, but the user ID/password pair was invalid.
                // Authentication was attempted but failed (set Result, not Principal).
                filterContext.Result = new HttpStatusCodeResult(401, "Invalid User ID or Password");
                return;
            }
            else
            {
                // The request contains a Basic authentication header, and the user ID/password pair was valid.
                // Authentication was attempted and succeeded (set Principal, not Result).
                filterContext.Principal = principal;
                return;
            }
        }

        private IPrincipal Authenticate(string userId, string password)
        {
            // For this sample, there is one password that works with any user ID.
            // All other passwords are invalid.
            if (password != Password)
            {
                return null;
            }

            // For this sample, a user only has a name (the user ID provided in the Basic credentials).
            Claim[] claims = new Claim[] { new Claim(ClaimTypes.Name, userId) };
            return new ClaimsPrincipal(new ClaimsIdentity(claims, "Basic"));
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            // Whenever the pipeline's response is 401 Unauthorized, we want to add a WWW-Authenticate: Basic header.
            // However, the pipeline's result hasn't yet been executed, so we can't check for 401 here.
            // Instead, we add a wrapper to the existing result. When our result gets executed, the first thing we do
            // is execute the original result. Then we can check the status code and add the challenge if it is a 401.
            filterContext.Result = new AddChallengeOnUnauthorizedResult("Basic", filterContext.Result);

            // An authentication filter likely does one of two things this method:
            // 1. Nothing (if it doesn't support authentication challenges).
            // 2. Always wrap the result as above (if it does support authentication challenges).
        }
    }
}
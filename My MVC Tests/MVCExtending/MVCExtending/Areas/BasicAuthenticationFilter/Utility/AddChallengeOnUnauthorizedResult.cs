using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCExtending.Areas.BasicAuthenticationFilter.Utility
{
    public class AddChallengeOnUnauthorizedResult : ActionResult
    {
        public AddChallengeOnUnauthorizedResult(string challenge, ActionResult innerResult)
        {
            if (innerResult == null)
            {
                throw new ArgumentNullException("innerResult");
            }

            Challenge = challenge;
            InnerResult = innerResult;
        }

        public string Challenge { get; private set; }
        public ActionResult InnerResult { get; private set; }

        public override void ExecuteResult(ControllerContext context)
        {
            // First, execute the inner result to see what the normal pipeline outcome is.
            InnerResult.ExecuteResult(context);

            HttpResponseBase response = context.HttpContext.Response;

            // If the outcome is a 401 Unauthorized, add the authentication challenge.
            if (response.StatusCode == 401)
            {
                var challenges = response.Headers.GetValues("WWW-Authenticate");

                // Don't add the same challenge twice.
                if (challenges == null || !challenges.Any(c => c == Challenge))
                {
                    response.Headers.Add("WWW-Authenticate", Challenge);
                }
            }
        }
    }
}
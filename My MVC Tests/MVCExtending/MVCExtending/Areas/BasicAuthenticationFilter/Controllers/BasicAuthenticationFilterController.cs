using System.Web.Mvc;
using MVCExtending.Areas.BasicAuthenticationFilter.Models;
using MVCExtending.Areas.BasicAuthenticationFilter.Utility;

namespace MVCExtending.Areas.BasicAuthenticationFilter.Controllers
{
    public class BasicAuthenticationFilterController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [BasicAuthentication(Password = "secret")]
        [Authorize]
        public ActionResult Authenticated()
        {
            User model = new User { Name = User.Identity.Name };
            return View(model);
        }
    }
}
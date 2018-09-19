using System.Web.Mvc;
using $rootnamespace$.Areas.BasicAuthenticationFilter.Models;
using $rootnamespace$.Areas.BasicAuthenticationFilter.Utility;

namespace $rootnamespace$.Areas.BasicAuthenticationFilter.Controllers
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
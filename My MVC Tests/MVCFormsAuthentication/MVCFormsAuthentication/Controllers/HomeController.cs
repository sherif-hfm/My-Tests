using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCFormsAuthentication.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Message = "Index";
            return View();
        }

        public ActionResult Login()
        {
            var user = User.Identity.IsAuthenticated;
            FormsAuthentication.SetAuthCookie("Sherif", true);
            ViewBag.Message = "Login";
            return View("index");
        }

        [Authorize]
        public ActionResult Data()
        {
            ViewBag.Message = "Data";
            return View("index");
        }

        [CustomAuthentication]
        public ActionResult Data2()
        {
            ViewBag.Message = "Data2";
            return View("index");
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            ViewBag.Message = "SignOut";
            return View("index");
        }
    }
}
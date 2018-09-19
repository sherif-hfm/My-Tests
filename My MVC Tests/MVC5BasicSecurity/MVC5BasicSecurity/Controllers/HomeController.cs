using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5BasicSecurity.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize(Roles ="Admin")]
        public ActionResult AdminPage()
        {
            ViewBag.Message = "Admin Page";

            return View();
        }

        [Authorize(Roles = "Admin,User1")]
        public ActionResult User1Page()
        {
            ViewBag.Message = "User1 Page";

            return View();
        }

        [Authorize(Roles = "Admin,User2")]
        public ActionResult User2Page()
        {
            ViewBag.Message = "User2 Page";

            return View();
        }
    }
}
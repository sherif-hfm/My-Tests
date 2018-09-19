using MVCBasics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBasics.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.CrDate = DateTime.Now.ToString();
          
            ViewBag.UserName = "sherif_hfm";
            Home home = new Home() { PageNameAr = "صفحة" };
            return View(home);
        }

        public ActionResult Message()
        {
            ViewBag.Message = "This is a partial view.";
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult CreateChildAction(string prm1)
        {
            ViewBag.Message = "Child Action Message " + prm1;
            return PartialView("ChildView");
        }
    }
}
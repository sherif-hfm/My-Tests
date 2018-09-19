using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Ajax.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public string AjaxText()
        {
            return "welcome to ajax";
        }

        public ActionResult AjaxView()
        {
            return View();
        }
    }
}
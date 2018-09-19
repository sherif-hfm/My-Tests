using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApp.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            System.Web.HttpContext.Current.Session["Test"] = "Session Test2: " + DateTime.Now.ToString();
            ViewBag.Message = Session["Test"];
            return View();
        }
    }
}
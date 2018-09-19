
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Areas.TLS.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Message = "TLS " + Session["Test"];
            return View();
        }

        public JsonResult GetData()
        {
            var data = "";
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}
    

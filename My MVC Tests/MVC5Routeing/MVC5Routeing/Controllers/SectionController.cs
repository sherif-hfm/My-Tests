using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Routeing.Controllers
{
    public class SectionController : Controller
    {
        // GET: Section
        public ActionResult Index(int id)
        {
            return View();
        }

        public ActionResult Report(int year, int month, int day)
        {
            ViewBag.Data = " Year : " + year.ToString();
            return View("Index");
        }
    }
}
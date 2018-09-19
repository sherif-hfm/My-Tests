using MVCAngular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAngular.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetData()
        {
            var data = new List<Person>();
            data.Add(new Person() { PersonName = "Sherif", PersonAge = 1 });
            data.Add(new Person() { PersonName = "Ahmed", PersonAge = 2 });
            data.Add(new Person() { PersonName = "Mohamed", PersonAge = 3 });
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}
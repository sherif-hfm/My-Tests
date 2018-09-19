using MVC5Ajax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Ajax.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult AddPerson()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPerson(Person _person)
        {
            return AddPerson();
        }

        public JsonResult QuickSearch(string term)
        {
            var result = new string[] { "Sherif", "Ahmed", "Mohamed", "Mostafa", "Islam", "Omar" };
            return Json((from s in result where s.StartsWith(term) select s), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Bootstrap()
        {
            return View();
        }
        
    }
}
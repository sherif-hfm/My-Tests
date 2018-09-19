using AngularBasics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngularBasics.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Basics()
        {
            return View();
        }

        public ActionResult Basics2()
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

        public JsonResult GetProductData()
        {
            var data = new List<Product>();
            data.Add(new Product() { name = "Proud1 Name", price = 1, description = "Proud1 Description",  canPurchase = true, soldOut = false, addDate = "01-01-2016", specification = "Proud1 Specification", reviews = new List<Review>() });
            data.Add(new Product() { name = "Proud2 Name", price = 2, description = "Proud2 Description",  canPurchase = true, soldOut = false, addDate = "01-02-2016", specification = "Proud2 Specification", reviews = new List<Review>() });
            data.Add(new Product() { name = "Proud3 Name", price = 3, description = "Proud3 Description",  canPurchase = true, soldOut = false, addDate = "01-03-2016", specification = "Proud3 Specification", reviews = new List<Review>() });
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [ChildActionOnly]
        public string GetAngular()
        {
            string result = "<product-Info></product-Info>";
            //string result = "Test";
            return result;
        }
    }
}
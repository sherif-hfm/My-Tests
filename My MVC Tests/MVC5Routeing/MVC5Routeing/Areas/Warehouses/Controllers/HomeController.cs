using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Routeing.Areas.Warehouses.Controllers
{
    //[RouteArea("Warehouses", AreaPrefix = "Warehouses")]
    //[Route("users/{action}")]
    //[Route("home2")]
    public class HomeController : Controller
    {
        // GET: Warehouses/Home
        //[Route("sherif")]
        public ActionResult Index()
        {
            return View();
            //return View("~/Areas/Warehouses/Views/Home/Index.cshtml");
        }
    }
}
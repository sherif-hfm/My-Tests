using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Routeing.Controllers
{

    //[RoutePrefix("home")]
    //[Route("home/{action=Index}")]
    //[Route("home/{action}")]
    public class HomeController : Controller
    {
        // GET: Home
        //[Route("")]
        //[Route("home/index")]

        public ActionResult Index()
        {
            return View();
        }

        [Route("About/")]
        public ActionResult About()
        {
            ViewBag.Data = "No data ";
            return View("About");
        }

        [Route("About/{data:regex(^\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*$)}")]
        public ActionResult AboutMail(string data)
        {
            ViewBag.Data = "string Mail " + data;
            return View("About");
        }

        [Route("About/{data:length(2,4)}")]
        public ActionResult About(string data)
        {
            ViewBag.Data = "string 2~4 " + data;
            return View();
        }


        [Route("About/{data:length(5,10)}")]
        public ActionResult About2(string data)
        {
            ViewBag.Data = "string 5~10 " + data;
            return View("About");
        }


       
        [Route("About/{data:int}")]
        public ActionResult About(int data)
        {
            ViewBag.Data = "int " + data.ToString();
            return View();
        }

        //[Route("{report}/{year}/{month}/{day}")]
        //public ActionResult Report(string report, int year)
        //{
        //    // http://localhost:8642/buy/2008/1/23
        //    ViewBag.Data = "Report  " + report + " Year : " + year.ToString();
        //    return View("About");
        //}

        public ActionResult Report(int year, int month, int day)
        {
            ViewBag.Data = " Year : " + year.ToString();
            return View("About");
        }
    }
}
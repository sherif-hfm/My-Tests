using MVCExtending.Areas.BasicAuthenticationFilter.Utility;
using MVCExtending.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Razor.Parser;

namespace MVCExtending.Controllers
{
    //[CustomResultFilter]
    public class HomeController : Controller
    {
        // GET: Home
        //[CustomActionName("Index")]
        //[ActionName("index2")]
        public ActionResult Index()
        {
            return View("index");
        }

        //[CustomActionMethod]
        public ActionResult Index2()
        {
            HttpContext.Response.AddHeader("test", "val");
            HttpContext.Response.Headers.Add("test", "val");
            ViewBag.Message = "Index 2";
            return View("index");
        }

        [CustomAuthentication]
        public ActionResult Index3()
        {
            var userCookie = new HttpCookie("MyCookie", "Data");
            userCookie.Expires.AddDays(365);
            HttpContext.Response.Cookies.Add(userCookie);
            ViewBag.Message = "Index 3";
            return View("index");
        }

        [CustomActionFilter]
        [CustomResultFilter]
        
        public ActionResult Index4()
        {
            ViewBag.Message = "Index 4";
            return View("index");
        }

        [CustomExceptionFilter]
        public ActionResult Index5()
        {
            //try
            //{
            throw (new Exception("asd"));
            ViewBag.Message = "Index 5 OK";
            return View("index");
            //}
            //catch (Exception)
            //{
            //    ViewBag.Message = "Index 5 Error";
            //    return View("index");
            //}
        }

        public ActionResult Index6()
        {
            ViewBag.Message = "Index 6";
            return new CustomResult();
        }

        public ActionResult Index7()
        {
            ViewBag.Message = "Index 7";
            //return  Redirect("~/home/index6");
            //return JavaScript("");
            return Json(null);
            //return File("", "");
            //return PartialView();
            //return Content("Content");
            //return new HttpStatusCodeResult(410);
        } 

        public ActionResult CustomTemplates()
        {
            ViewBag.Scripts = @"<script src=""/Scripts/SpecialDateTime.js""></script>";
            Person person = new Person();
            person.BirthDate = DateTime.Now.ToString();
            return View(person);
        }

        
    }
}
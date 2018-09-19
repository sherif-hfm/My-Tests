using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UploadFiles.Models;

namespace UploadFiles.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(PersonInfo _personInfo)
        {
            _personInfo.Image1.SaveAs(@"D:\Image1.jpg");
            _personInfo.Image2.SaveAs(@"D:\Image2.jpg");
            return View();
        }
    }
}
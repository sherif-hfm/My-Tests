﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Routeing.Areas.Security.Controllers
{
    public class HomeController : Controller
    {
        // GET: Security/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}
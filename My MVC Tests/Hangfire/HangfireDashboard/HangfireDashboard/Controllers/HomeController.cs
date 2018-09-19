﻿using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HangfireDashboard.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HangfireClient.CilentJobs job = new HangfireClient.CilentJobs();
            BackgroundJob.Enqueue(() => job.DoJob1());
            return View();
        }

        public ActionResult About()
        {

            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
    }
}
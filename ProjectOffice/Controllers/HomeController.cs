﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectOffice.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "About";

            return PartialView("~/Views/Home/About/Index.cshtml");
        }

        public ActionResult AboutIntro()
        {
            ViewBag.Message = "AboutIntro";

            return PartialView("~/Views/Home/About/Intro.cshtml");
        }

        public ActionResult Blog()
        {
            ViewBag.Message = "Blog";

            return PartialView("~/Views/Home/Blog/Index.cshtml");
        }

        public ActionResult BlogIntro()
        {
            ViewBag.Message = "BlogIntro";

            return PartialView("~/Views/Home/Blog/Intro.cshtml");
        }

        public ActionResult Features()
        {
            ViewBag.Message = "Features";

            return PartialView("~/Views/Home/Features/Index.cshtml");
        }

        public ActionResult FeaturesIntro()
        {
            ViewBag.Message = "FeaturesIntro";

            return PartialView("~/Views/Home/Features/Intro.cshtml");
        }

        public ActionResult Portfolio()
        {
            ViewBag.Message = "Portfolio";

            return PartialView("~/Views/Home/Portfolio/Index.cshtml");
        }

        public ActionResult PortfolioIntro()
        {
            ViewBag.Message = "PortfolioIntro";

            return PartialView("~/Views/Home/Portfolio/Intro.cshtml");
        }

        public ActionResult PromotionIntro()
        {
            ViewBag.Message = "Promotion";

            return PartialView("~/Views/Home/Promotion/Intro.cshtml");
        }

        public ActionResult Promotion()
        {
            ViewBag.Message = "Promotion";

            return PartialView("~/Views/Home/Promotion/Index.cshtml");
        }

        public ActionResult Service()
        {
            ViewBag.Message = "Service";

            return PartialView("~/Views/Home/Service/Index.cshtml");
        }

        public ActionResult ServiceIntro()
        {
            ViewBag.Message = "Service";

            return PartialView("~/Views/Home/Service/Intro.cshtml");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return PartialView("~/Views/Home/Contact/Intro.cshtml");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectOffice.Controllers
{
    public class FormsController : Controller
    {
        // GET: Forms
        public ActionResult Index()
        {
            ViewBag.Title = "Forms";
            return View();
        }

        public ActionResult AddServerIntro()
        {
            ViewBag.Title = "Add Server";

            return PartialView("~/Views/Forms/AddServer/Intro.cshtml");
        }

        public ActionResult AddServer()
        {
            ViewBag.Title = "Add Server";

            return PartialView("~/Views/Forms/AddServer/Index.cshtml");
        }

    }
}
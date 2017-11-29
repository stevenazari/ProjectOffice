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

        //Form creator tool to make form generation data driven (Work in progress)
        public ActionResult createForm()
        {
            ViewBag.Title = "Create Form";

            return PartialView("~/Views/Forms/createForm/Index.cshtml");
        }

        //Add server section
        public ActionResult ApplicationList()
        {
            return PartialView("~/Views/Forms/ApplicationsList/Index.cshtml");
        }

        public ActionResult ApplicationListIntro()
        {
            return PartialView("~/Views/Forms/ApplicationsList/Intro.cshtml");
        }

        //Add server section
        public ActionResult AddServer()
        {
            ViewBag.Title = "Add Server";

            return PartialView("~/Views/Forms/ApplicationsList/AddServer/Index.cshtml");
        }

        public ActionResult AddServerIntro()
        {
            ViewBag.Title = "Add Server";

            return PartialView("~/Views/Forms/ApplicationsList/AddServer/Intro.cshtml");
        }

        //Add application section
        public ActionResult AddApplication()
        {
            ViewBag.Title = "Add Application";

            return PartialView("~/Views/Forms/ApplicationsList/AddApplication/Index.cshtml");
        }

        public ActionResult AddApplicationIntro()
        {
            ViewBag.Title = "Add Application";

            return PartialView("~/Views/Forms/ApplicationsList/AddApplication/Intro.cshtml");
        }

        //Add Support Company section
        public ActionResult AddSupportCompany()
        {
            ViewBag.Title = "Add Support Company";

            return PartialView("~/Views/Forms/ApplicationsList/AddSupportCompany/Index.cshtml");
        }

        public ActionResult AddSupportCompanyIntro()
        {
            ViewBag.Title = "Add Support Company";

            return PartialView("~/Views/Forms/ApplicationsList/AddSupportCompany/Intro.cshtml");
        }
    }
}
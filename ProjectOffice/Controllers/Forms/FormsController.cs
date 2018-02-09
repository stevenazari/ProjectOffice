using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectOffice.Controllers.Forms
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
    }
}
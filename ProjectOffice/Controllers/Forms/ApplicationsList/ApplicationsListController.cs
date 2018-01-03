using System;
using System.Web.Mvc;
using System.Data;
using System.Reflection;
using System.Diagnostics;
using System.Linq;
using ProjectOffice.Models.Forms.ApplicationList;
using System.Collections.Generic;
using System.Web;

namespace ProjectOffice.Controllers.Forms.ApplicationsList
{
    public class ApplicationsListController : Controller
    {
        // GET: ApplicationList
        [Route("Forms/ApplicationsList")]
        public ActionResult Index()
        {
            var resultEnvironments = DBClassController.SQLConnection("Select_Environments", "1");
            string message = resultEnvironments.Item1;
            DataTable environmentsTable = resultEnvironments.Item2;

            return View("~/Views/Forms/ApplicationsList/Index.cshtml", environmentsTable);
        }

        public ActionResult ApplicationListIntro()
        {
            return PartialView("~/Views/Forms/ApplicationsList/Intro.cshtml");
        }

    }
}
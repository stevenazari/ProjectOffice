using System;
using System.Web.Mvc;
using System.Data;
using ProjectOffice.Models.Forms.SoftwareCatalogue;

namespace ProjectOffice.Controllers.Forms.SoftwareCatalogue
{
    public class SoftwareCatalogueController : Controller
    {
        public DBClassController dbObject = new DBClassController();
        public static EnvironmentListModel EnvironmentList = new EnvironmentListModel();

        // GET: EnvironmentList
        [Route("Forms/SoftwareCatalogue")]
        public ActionResult Index()
        {
            var resultEnvironments = dbObject.SQLConnection("Select_Environments", "1");
            string message = resultEnvironments.Item1;
            DataTable environmentsTable = resultEnvironments.Item2;

            return View("~/Views/Forms/SoftwareCatalogue/Index.cshtml", environmentsTable);
        }

        public ActionResult EnvironmentListTable()
        {
            return PartialView("~/Views/Forms/SoftwareCatalogue/EnvironmentListTable.cshtml");
        }
    }
}
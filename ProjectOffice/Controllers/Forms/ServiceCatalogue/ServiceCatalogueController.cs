using System;
using System.Web.Mvc;
using System.Data;
using ProjectOffice.Models.Forms.ServiceCatalogue;

namespace ProjectOffice.Controllers.Forms.ServiceCatalogue
{
    public class ServiceCatalogueController : Controller
    {
        public DBClassController dbObject = new DBClassController();
        public static EnvironmentListModel EnvironmentList = new EnvironmentListModel();

        // GET: EnvironmentList
        [Route("Forms/ServiceCatalogue")]
        public ActionResult Index()
        {
            var resultEnvironments = dbObject.SQLConnection("Select_Environments", "1");
            string message = resultEnvironments.Item1;
            DataTable environmentsTable = resultEnvironments.Item2;

            return View("~/Views/Forms/ServiceCatalogue/Index.cshtml", environmentsTable);
        }

        public ActionResult EnvironmentListTable()
        {
            return PartialView("~/Views/Forms/ServiceCatalogue/EnvironmentListTable.cshtml");
        }
    }
}
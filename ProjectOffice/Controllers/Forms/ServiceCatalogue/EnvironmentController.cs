using System;
using System.Web.Mvc;
using System.Data;
using System.Reflection;
using System.Diagnostics;
using System.Linq;
using ProjectOffice.Models.Forms.ServiceCatalogue.Environment;
using Newtonsoft.Json;


namespace ProjectOffice.Controllers.Forms.ServiceCatalogue.Environment
{
    public class EnvironmentController : Controller
    {
        public DBClassController dbObject = new DBClassController();
        string message = "";
        string jsonResult = "";
        string procedureValues = "";
        DataTable payload = null;

        // GET: Environment
        public ActionResult Create_Environment()
        {
            ViewBag.Title = "Add Environment";
            var model = new ProjectOffice.Models.Forms.ServiceCatalogue.Environment.EnvironmentModel();

            return PartialView("~/Views/Forms/ServiceCatalogue/Environment/Create_Environment.cshtml", model);
        }

        [HttpPost]
        public JsonResult Save(EnvironmentModel data)
        {
            string message = "";
            string jsonResult = "";
            string procedureValues = "";
            DataTable payload = null;

            procedureValues = dbObject.checkDataType(data);

            if (ModelState.IsValid)
            {
                var result = dbObject.SQLConnection("Insert_Environment", procedureValues);
                message = result.Item1;
                payload = result.Item2;
            }
            else
            {
                var err = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));

                message = "Please provide required fields: " + err;
            }

            jsonResult = dbObject.BuildDataTableToJson(payload);

            var jsonResponse = new { message = message, results = jsonResult };
            return Json(jsonResponse, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Update(EnvironmentModel data)
        {
            string message = "";
            string jsonResult = "";
            string procedureValues = "";
            DataTable payload = null;

            procedureValues = dbObject.checkDataType(data);

            if (ModelState.IsValid)
            {
                var result = dbObject.SQLConnection("Update_Environment", procedureValues);
                message = result.Item1;
                payload = result.Item2;
            }
            else
            {
                var err = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));

                message = "Please provide required fields: " + err;
            }

            jsonResult = dbObject.BuildDataTableToJson(payload);

            var jsonResponse = new { message = message, results = jsonResult };
            return Json(jsonResponse, JsonRequestBehavior.AllowGet);
        }

        public string GetEnvironments(EnvironmentModel data)
        {
            int rowCount = 0;
            string procedureValues = "";

            DataTable payload = null;
            procedureValues = dbObject.checkDataType(data);

            var resultEnvironments = dbObject.SQLConnection("Select_Environments", procedureValues);
            rowCount = resultEnvironments.Item2.Rows.Count;
            payload = resultEnvironments.Item2;

            var jsonResponse = new { total = rowCount, rows = payload, vars = procedureValues };
            string jsonDone = JsonConvert.SerializeObject(jsonResponse);

            return jsonDone;
        }

        // GET: Server
        public ActionResult EnvironmentDetails(EnvironmentModel data)
        {
            var model = new EnvironmentModel();
            ViewBag.environmentDetails = model.EnvironmentDetails(data.ID);
            ViewBag.ID = data.ID;

            return PartialView("~/Views/Forms/ServiceCatalogue/Environment/Environment_Details.cshtml", model);
        }

        public ActionResult EnvironmentListIntro()
        {
            return PartialView("~/Views/Forms/ServiceCatalogue/Intro.cshtml");
        }

        [HttpPost]
        public JsonResult Delete_Environment_Item(Delete_Environment_Item_Model data)
        {
            procedureValues = dbObject.checkDataType(data);

            if (ModelState.IsValid)
            {
                var result = dbObject.SQLConnection("Delete_Environment_Item", procedureValues);
                message = result.Item1;
                payload = result.Item2;

                if (message.ToLower().Contains("error"))
                {
                    message = message + ", Error_Values = " + procedureValues;
                }
            }
            else
            {
                var err = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));

                message = "Please provide required fields: " + err;
            }

            jsonResult = dbObject.BuildDataTableToJson(payload);

            var jsonResponse = new { message = message, results = jsonResult };
            return Json(jsonResponse, JsonRequestBehavior.AllowGet);
        }

    }
}
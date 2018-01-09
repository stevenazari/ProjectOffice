using System;
using System.Web.Mvc;
using System.Data;
using System.Reflection;
using System.Diagnostics;
using System.Linq;
using ProjectOffice.Models.Forms.ApplicationList.Environment;

namespace ProjectOffice.Controllers.FormControllers.ApplicationListController
{
    public class EnvironmentController : Controller
    {
        // GET: Application
        public ActionResult Index()
        {
            ViewBag.Title = "Add Application";

            return PartialView("~/Views/Forms/ApplicationsList/AddEnvironment/View.cshtml");
        }


        public ActionResult AddApplicationIntro()
        {
            ViewBag.Title = "Add Application";

            return PartialView("~/Views/Forms/ApplicationsList/AddEnvironment/Intro.cshtml");
        }

        [HttpPost]
        public JsonResult Save(EnvironmentModel data)
        {
            string message = "";
            string jsonResult = "";
            string procedureValues = "";
            DataTable payload = null;

            procedureValues = BuildProcedureValues(data);

            if (ModelState.IsValid)
            {
                var result = DBClassController.SQLConnection("Insert_Environment", procedureValues);
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

            jsonResult = DBClassController.BuildDataTableToJson(payload);

            var jsonResponse = new { message = message, results = jsonResult };
            return Json(jsonResponse, JsonRequestBehavior.AllowGet);
        }

        public string BuildProcedureValues(EnvironmentModel data)
        {
            string returnValue = "";
            Type type = data.GetType();
            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                if (property.GetValue(data, null) is null)
                {
                    returnValue += "@" + property.Name + " = " + "NULL, ";
                }
                else if (property.GetValue(data, null) is string)
                {
                    returnValue += "@" + property.Name + " = '" + property.GetValue(data, null) + "', ";
                }
                else if (property.GetValue(data, null) is int)
                {
                    returnValue += "@" + property.Name + " = " + property.GetValue(data, null) + ", ";
                }
                else if (property.GetValue(data, null) is bool)
                {
                    returnValue += "@" + property.Name + " = " + property.GetValue(data, null) + ", ";
                }
                else if (property.GetValue(data, null) is DateTime)
                {
                    returnValue += "@" + property.Name + " = '" + property.GetValue(data, null) + "', ";
                }
                else
                {
                    returnValue += "@" + property.Name + " = '" + property.GetValue(data, null) + "', ";
                }
            }

            returnValue = returnValue.Remove(returnValue.Length - 2);

            return returnValue;
        }
    }
}
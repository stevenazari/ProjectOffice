using System;
using System.Web.Mvc;
using System.Data;
using System.Reflection;
using System.Diagnostics;
using System.Linq;
using ProjectOffice.Models.Forms.ApplicationList.Application;



namespace ProjectOffice.Controllers.FormControllers.ApplicationListController
{
    public class ApplicationController : Controller
    {
        // GET: Application
        public ActionResult Index()
        {
            ViewBag.Title = "Add Application";

            return PartialView("~/Views/Forms/ApplicationsList/AddApplication/Index.cshtml");
        }


        public ActionResult AddApplicationIntro()
        {
            ViewBag.Title = "Add Application";

            return PartialView("~/Views/Forms/ApplicationsList/AddApplication/Intro.cshtml");
        }

        [HttpPost]
        public JsonResult Save(ApplicationModel data)
        {
            string message = "";
            string jsonResult = "";
            string procedureValues = "";
            DataTable payload = null;

            procedureValues = BuildProcedureValues(data);

            if (ModelState.IsValid)
            {
                var result = DBClassController.SQLConnection("Insert_Applications", procedureValues);
                message = result.Item1;
                payload = result.Item2;

                //Debug.WriteLine("Message: " + message + "Payload: " + payload); 
            }
            else
            {
                var err = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));

                Debug.WriteLine("ModelState Failed " + err);
                message = "Please provide required fields: " + err;
            }

            jsonResult = DBClassController.BuildDataTableToJson(payload);

            var jsonResponse = new { message = message, results = jsonResult };
            return Json(jsonResponse, JsonRequestBehavior.AllowGet);
        }

        public string BuildProcedureValues(ApplicationModel data)
        {
            string returnValue = "";
            Type type = data.GetType();
            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                if (property.GetValue(data, null) is null)
                {
                    //Debug.WriteLine("type: " + property.GetType() + " value = null");
                    returnValue += "@" + property.Name + " = " + "NULL, ";
                }
                else if (property.GetValue(data, null) is string)
                {
                    //Debug.WriteLine("type: " + property.GetType() + " value = string");
                    returnValue += "@" + property.Name + " = '" + property.GetValue(data, null) + "', ";
                }
                else if (property.GetValue(data, null) is int)
                {
                    //Debug.WriteLine("type: " + property.GetType() + " value = Int");
                    returnValue += "@" + property.Name + " = " + property.GetValue(data, null) + ", ";
                }
                else if (property.GetValue(data, null) is bool)
                {
                    //Debug.WriteLine("type: " + property.GetType() + " value = bool");
                    returnValue += "@" + property.Name + " = " + property.GetValue(data, null) + ", ";
                }
                else if (property.GetValue(data, null) is DateTime)
                {
                    //Debug.WriteLine("type: " + property.PropertyType + " value = " + property.GetValue(data, null));
                    returnValue += "@" + property.Name + " = '" + property.GetValue(data, null) + "', ";
                }
                else
                {
                    //Debug.WriteLine("Unknown type: " + property.GetType() + "unknown value: " + property.GetValue(data, null));
                    returnValue += "@" + property.Name + " = '" + property.GetValue(data, null) + "', ";
                }
            }

            returnValue = returnValue.Remove(returnValue.Length - 2);

            return returnValue;
        }
    }
}
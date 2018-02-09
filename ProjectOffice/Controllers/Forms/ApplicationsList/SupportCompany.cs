using System;
using System.Web.Mvc;
using ProjectOffice.Models.Forms.ApplicationList.SupportCompany;
using ProjectOffice.Controllers;
using System.Data;
using System.Reflection;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;

namespace ProjectOffice.Controllers.FormsController.ApplicationsListController
{
    public class SupportCompanyController : Controller
    {
        // GET: SupportCompany
        public ActionResult Index()
        {
            var resultCompanies = DBClassController.SQLConnection("Select_Support_Companies", "1");
            DataTable companiesTable = resultCompanies.Item2;

            ViewBag.SupportCompaniesTable = companiesTable;
            ViewBag.Title = "Add Support Company";

            return PartialView("~/Views/Forms/ApplicationsList/AddSupportCompany/Index.cshtml");
        }

        public ActionResult AddSupportCompanyIntro()
        {
            ViewBag.Title = "Add Support Company";

            return PartialView("~/Views/Forms/ApplicationsList/AddSupportCompany/Intro.cshtml");
        }

        [HttpPost]
        public JsonResult Save(SupportCompanyModel data)
        {
            string message = "";
            string procedureValues = "";
            string jsonResult = "";
            DataTable payload = null;

            procedureValues = BuildProcedureValues(data);

            if (ModelState.IsValid)
            {
                var result = DBClassController.SQLConnection("Insert_Support_Companies", procedureValues);
                message = result.Item1;
                payload = result.Item2;
            }
            else
            {
                message = "Please provide required fields.";
            }

            jsonResult = DBClassController.BuildDataTableToJson(payload);

            var jsonResponse = new { message = message, results = jsonResult };
            return Json(jsonResponse, JsonRequestBehavior.AllowGet);
        }

        public string BuildProcedureValues(SupportCompanyModel data)
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
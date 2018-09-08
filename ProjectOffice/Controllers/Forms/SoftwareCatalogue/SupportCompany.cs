using System;
using System.Web.Mvc;
using ProjectOffice.Models.Forms.SoftwareCatalogue.SupportCompany;
using ProjectOffice.Controllers;
using System.Data;
using System.Reflection;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;

namespace ProjectOffice.Controllers.Forms.SoftwareCatalogueController
{
    public class SupportCompanyController : Controller
    {
        public DBClassController dbObject = new DBClassController();
        string message = "";
        string jsonResult = "";
        string procedureValues = "";
        DataTable payload = null;

        // GET: SupportCompany
        public ActionResult Create_Support_Company()
        {
            var resultCompanies = dbObject.SQLConnection("Select_Support_Companies", "1");
            DataTable companiesTable = resultCompanies.Item2;

            ViewBag.SupportCompaniesTable = companiesTable;
            ViewBag.Title = "Add Support Company";
            var model = new ProjectOffice.Models.Forms.SoftwareCatalogue.SupportCompany.SupportCompanyModel();

            return PartialView("~/Views/Forms/SoftwareCatalogue/SupportCompany/Index.cshtml", model);
        }

        public ActionResult SupportCompanyIntro()
        {
            ViewBag.Title = "Add Support Company";

            return PartialView("~/Views/Forms/SoftwareCatalogue/SupportCompany/Intro.cshtml");
        }

        [HttpPost]
        public JsonResult Save(SupportCompanyModel data)
        {
            procedureValues = dbObject.checkDataType(data);

            if (ModelState.IsValid)
            {
                var result = dbObject.SQLConnection("Insert_Support_Companies", procedureValues);
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

        public JsonResult SupportCompanyValidation(string Name)
        {
            //procedureValues = dbObject.checkDataType(supportCompany);

            var result = dbObject.SQLConnection("Select_Support_Companies", "@NAME = N'" + Name + "'");
            message = result.Item1;
            payload = result.Item2;
            bool notExists = true;

            if (payload.Rows.Count > 0)
            {
                notExists = false;
            }

            return Json(notExists, JsonRequestBehavior.AllowGet);
        }
    }
}
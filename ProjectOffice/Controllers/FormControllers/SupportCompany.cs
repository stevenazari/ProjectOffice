using System;
using System.Web.Mvc;
using ProjectOffice.Models.Forms.SupportCompany;
using ProjectOffice.Controllers;
using System.Data;
using System.Reflection;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace ProjectOffice.Controllers.FormControllers
{
    public class SupportCompanyController : Controller
    {
        // GET: SupportCompany
        public ActionResult save()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save()
        {
            string message = "";
            DataTable payload = null;
            string jsonResult = "";

            if (ModelState.IsValid)
            {
                var result = DBClassController.SQLConnection("Insert_Support_Companies", buildSupportCompanyFields());
                message = result.Item1;
                payload = result.Item2;
            }
            else
            {
                message = "Please provide required fields.";
            }

            jsonResult = DBClassController.BuildDataTableToJson(payload);

            if (Request.IsAjaxRequest())
            {
                var jsonResponse = new { message = message, results = jsonResult };
                return Json(jsonResponse, JsonRequestBehavior.AllowGet);
            }
            else
            {
                ViewBag.Message = message;
                return View(payload);
            }
        }

        public static StringDictionary buildSupportCompanyFields()
        {
            SupportCompanyModel supportCompany = new SupportCompanyModel();
            Type SCD = supportCompany.GetType();
            PropertyInfo[] properties = SCD.GetProperties();
            StringDictionary dict = new StringDictionary();

            foreach (PropertyInfo property in properties)
            {
                dict.Add(property.Name, property.GetValue(supportCompany, null).ToString());
            }

            return dict;
        }
        /*
                public JsonResult GetSupportCompany(Support_Companies searchCriteria)
                {
                    DBClassController addCompany = new DBClassController();
                    result.Text = addCompany.SQLConnection("Select_Support_Company", searchCriteria);

                    return Json(SupportCompany, JsonRequestBehavior.AllowGet);
                }
        */
    }
}
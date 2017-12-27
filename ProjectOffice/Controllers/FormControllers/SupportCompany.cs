using System;
using System.Web.Mvc;
using ProjectOffice.Models.Forms.SupportCompany;
using ProjectOffice.Controllers;
using System.Data;
using System.Reflection;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;

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
        public JsonResult Save(SupportCompanyModel supportCompanyData)
        {
            string message = "";
            string procedureValues = "";
            string jsonResult = "";
            DataTable payload = null;
            Type type = supportCompanyData.GetType();
            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                if (property.GetValue(supportCompanyData, null) is null)
                {
                    //Debug.WriteLine("type: " + property.GetType() + " value = null");
                    procedureValues += "@" + property.Name + " = " + "NULL, ";
                }
                else if (property.GetValue(supportCompanyData, null) is string)
                {
                    //Debug.WriteLine("type: " + property.GetType() + " value = string");
                    procedureValues += "@" + property.Name + " = '" + property.GetValue(supportCompanyData, null) + "', ";
                }
                else if (property.GetValue(supportCompanyData, null) is int)
                {
                    //Debug.WriteLine("type: " + property.GetType() + " value = Int");
                    procedureValues += "@" + property.Name + " = " + property.GetValue(supportCompanyData, null) + ", ";
                }
                else if (property.GetValue(supportCompanyData, null) is bool)
                {
                    //Debug.WriteLine("type: " + property.GetType() + " value = bool");
                    procedureValues += "@" + property.Name + " = " + property.GetValue(supportCompanyData, null) + ", ";
                }
                else if (property.GetValue(supportCompanyData, null) is DateTime)
                {
                    //Debug.WriteLine("type: " + property.PropertyType + " value = " + property.GetValue(supportCompanyData, null));
                    procedureValues += "@" + property.Name + " = '" + property.GetValue(supportCompanyData, null) + "', ";
                }
                else
                {
                    //Debug.WriteLine("Unknown type: " + property.GetType() + "unknown value: " + property.GetValue(supportCompanyData, null));
                    procedureValues += "@" + property.Name + " = '" + property.GetValue(supportCompanyData, null) + "', ";
                }
            }

            procedureValues = procedureValues.Remove(procedureValues.Length - 2);

            if (ModelState.IsValid)
            {
                var result = DBClassController.SQLConnection("Insert_Support_Companies", procedureValues);
                message = result.Item1;
                payload = result.Item2;

                //Debug.WriteLine("Message: " + message + "Payload: " + payload); 
            }
            else
            {
                Debug.WriteLine("ModelState Failed ");
                message = "Please provide required fields.";
            }

            jsonResult = DBClassController.BuildDataTableToJson(payload);

            var jsonResponse = new { message = message, results = jsonResult };
            return Json(jsonResponse, JsonRequestBehavior.AllowGet);
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
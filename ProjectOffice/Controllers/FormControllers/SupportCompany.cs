    using System;
    using System.Web.Mvc;
    using ProjectOffice.Models.Forms.SupportCompany
    using ProjectOffice.Controllers;

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
        public ActionResult save(SupportCompanyModel SupportCompanyData)
        {
            String message = "";

            if (ModelState.IsValid)
            {
                DBClassController addCompany = new DBClassController();
                message = addCompany.SQLConnection("Insert_Support_Companies", SupportCompanyData);
            }
            else
            {
                message = "Please provide required fields.";
            }

            if (Request.IsAjaxRequest())
            {
                return new JsonResult
                {
                    Data = message,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            else
            {
                ViewBag.Message = message;
                return View(SupportCompanyData);
            }
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
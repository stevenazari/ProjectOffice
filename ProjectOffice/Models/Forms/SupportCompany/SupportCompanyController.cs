using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectOffice.Models.Forms.SupportCompany
{
    public class SupportCompanyModel : Controller
    {
        public string Support_Name { get; set; }
        public string Support_Address_1 { get; set; }
        public string Support_Address_2 { get; set; }
        public string Support_Post_Code { get; set; }
        public string Support_Tel { get; set; }
        public string Support_Email { get; set; }
        public string Support_Website { get; set; }
        public string Support_Out_Of_Hours { get; set; }
        public string Support_Comment { get; set; }

        // GET: form
        public ActionResult Index()
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectOffice.Controllers;
using System.Data;
using System.Web.UI.WebControls;

namespace ProjectOffice.Models.Forms.ApplicationList.Application
{
    public class ApplicationModel
    {
        public int? Get_All { get; set; }
        public string ORDER_BY { get; set; }
        public int? ID { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public int Application_Type_ID { get; set; }
        public int Support_Company_ID { get; set; }
        public string Comment { get; set; }
        public string Last_Used { get; set; } = DateTime.Now.ToString("yyyy-MM-dd h:mm tt");
        public string Created { get; set; } = DateTime.Now.ToString("yyyy-MM-dd h:mm tt");
        public bool? Status { get; set; }
        public bool? Deleted { get; set; }

        public static SelectList GetSupportCompanies()
        {
            var resultCompanies = DBClassController.SQLConnection("Select_Support_Companies", "1");
            string message = resultCompanies.Item1;
            DataTable companiesTable = resultCompanies.Item2;

            return new SelectList(companiesTable.AsDataView(), "ID", "Name");
        }

        public static SelectList GetApplicationTypes()
        {
            var resultApplicationTypes = DBClassController.SQLConnection("Select_Application_Package_Types", null);
            string message = resultApplicationTypes.Item1;
            DataTable applicationTypeTable = resultApplicationTypes.Item2;

            return new SelectList(applicationTypeTable.AsDataView(), "ID", "Name");
        }
    }
}
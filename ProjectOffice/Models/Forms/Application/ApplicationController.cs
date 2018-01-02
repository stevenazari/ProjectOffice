using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectOffice.Controllers;
using System.Data;
using System.Web.UI.WebControls;

namespace ProjectOffice.Models.Forms.Application
{
    public class ApplicationModel
    {
        public string ORDER_BY { get; set; }
        public int? Get_All { get; set; }
        public int? ID { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public int Support_Company_ID { get; set; }
        public int Package_Type_ID { get; set; }
        public string Comment { get; set; }
        public DateTime Last_Used { get; set; } = DateTime.Now;
        public DateTime Created { get; set; } = DateTime.Now;
        public bool? Status { get; set; }
        public bool? Deleted { get; set; }

        public static SelectList GetSupportCompanies()
        {
            var resultCompanies = DBClassController.SQLConnection("Select_Support_Companies", "1");
            string message = resultCompanies.Item1;
            DataTable companiesTable = resultCompanies.Item2;

            return new SelectList(companiesTable.AsDataView(), "ID", "Name");
        }

        public static SelectList GetPackageTypes()
        {
            var resultPackageTypes = DBClassController.SQLConnection("Select_Application_Package_Types", null);
            string message = resultPackageTypes.Item1;
            DataTable PackageTypeTable = resultPackageTypes.Item2;

            return new SelectList(PackageTypeTable.AsDataView(), "ID", "Name");
        }
    }
}
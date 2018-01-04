using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectOffice.Controllers;
using System.Data;
using System.Web.UI.WebControls;

namespace ProjectOffice.Models.Forms.ApplicationList.Environment
{
    public class EnvironmentModel
    {
        public int? Get_All { get; set; }
        public string ORDER_BY { get; set; }
        public int? ID { get; set; }
        public int Application_ID { get; set; }
        public int? Support_Company_ID { get; set; }
        public int Server_ID { get; set; }
        public int Environment_Type_ID { get; set; }
        public string Comment { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public bool? Deleted { get; set; }

        public static SelectList GetApplications()
        {
            var resultCompanies = DBClassController.SQLConnection("Select_Applications", "1");
            string message = resultCompanies.Item1;
            DataTable companiesTable = resultCompanies.Item2;

            return new SelectList(companiesTable.AsDataView(), "ID", "Name");
        }

        public static SelectList GetServers()
        {
            var resultPackageTypes = DBClassController.SQLConnection("Select_Servers", "1");
            string message = resultPackageTypes.Item1;
            DataTable PackageTypeTable = resultPackageTypes.Item2;

            return new SelectList(PackageTypeTable.AsDataView(), "ID", "Name");
        }

        public static SelectList GetEnvironmentTypes()
        {
            var resultEnvironmentTypes = DBClassController.SQLConnection("Select_Environment_Types", null);
            string message = resultEnvironmentTypes.Item1;
            DataTable environmentTypeTable = resultEnvironmentTypes.Item2;

            return new SelectList(environmentTypeTable.AsDataView(), "ID", "Name");
        }
    }
}
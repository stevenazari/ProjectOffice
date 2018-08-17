using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectOffice.Controllers;
using System.Data;
using System.Web.UI.WebControls;
using ProjectOffice.Models.Forms.SoftwareCatalogue.Server;

namespace ProjectOffice.Models.Forms.SoftwareCatalogue.Application
{
    public class Create_Application_Model
    {
        public DBClassController dbObject = new DBClassController();

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

        public SelectList GetSupportCompanies()
        {
            var resultCompanies = dbObject.SQLConnection("Select_Support_Companies", "1");
            string message = resultCompanies.Item1;
            DataTable companiesTable = resultCompanies.Item2;

            return new SelectList(companiesTable.AsDataView(), "ID", "Name");
        }

        public SelectList GetApplicationTypes()
        {
            var resultApplicationTypes = dbObject.SQLConnection("Select_Application_Package_Types", null);
            string message = resultApplicationTypes.Item1;
            DataTable applicationTypeTable = resultApplicationTypes.Item2;

            return new SelectList(applicationTypeTable.AsDataView(), "ID", "Name");
        }
    }
    
    public class Add_Application_Model
    {
        public DBClassController dbObject = new DBClassController();

        public int? Item_ID { get; set; }
        public int? Item_Type_ID { get; set; }
        public int? Parent_ID { get; set; }
        public int? Environment_ID { get; set; }

        public SelectList Add_Server(int EnvironmentID)
        {
            Add_Server_Model Server_Object = new Add_Server_Model();
            return Server_Object.GetServersList(EnvironmentID, 0);

        }

        public SelectList GetApplications()
        {
            var resultApplicationList = dbObject.SQLConnection("Select_Application_List", null);
            string message = resultApplicationList.Item1;
            DataTable applicationListTable = resultApplicationList.Item2;

            return new SelectList(applicationListTable.AsDataView(), "ID", "Application_Name");
        }
    }
}
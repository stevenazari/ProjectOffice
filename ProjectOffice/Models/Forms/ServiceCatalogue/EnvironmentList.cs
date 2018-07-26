using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectOffice.Controllers;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.Helpers;
using Newtonsoft.Json;
using System.Diagnostics;




namespace ProjectOffice.Models.Forms.ServiceCatalogue
{
    public class EnvironmentListModel
    {
        public DBClassController dbObject = new DBClassController();

        public int? SEARCH { get; set; }
        public string ORDER_BY { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Environment_Type { get; set; }
        public string Comment { get; set; }
        /*public string Application_ID { get; set; }
        public string Support_Company_ID { get; set; }
        public string Server_ID { get; set; }
        public string Environment_Type_ID { get; set; }
        public string Created { get; set; }
        public string Deleted { get; set; }
        public string Order { get; set; }
        public string Offset { get; set; }
        public string Sort { get; set; }
        public string Limit { get; set; }
        public string Search { get; set; }
        */
        public DataView GetEnvironments()
        {
            var resultEnvironments = dbObject.SQLConnection("Select_Environments", null);
            string message = resultEnvironments.Item1;
            DataTable EnvironmentListTable = resultEnvironments.Item2;

            return EnvironmentListTable.AsDataView();
        }

        public DataView EnvironmentDetails(int ID)
        {
            var resultEnvironments = dbObject.SQLConnection("Select_Environment_Details", ID.ToString());
            string message = resultEnvironments.Item1;
            DataTable environmentDetails = resultEnvironments.Item2;

            return environmentDetails.AsDataView();
        }
    }

}
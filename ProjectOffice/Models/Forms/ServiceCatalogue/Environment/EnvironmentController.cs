using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectOffice.Controllers;
using System.Data;
using System.Web.UI.WebControls;

namespace ProjectOffice.Models.Forms.ServiceCatalogue.Environment
{
    public class EnvironmentModel
    {
        public DBClassController dbObject = new DBClassController();

        public string search { get; set; }
        public string ORDER_BY { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public Int32? Environment_Type_ID { get; set; }
        public string Environment_Type { get; set; }
        public string Comment { get; set; }
        public string Created { get; set; }
        public bool? Deleted { get; set; }

        public SelectList GetEnvironmentTypes()
        {
            var resultEnvironmentTypes = dbObject.SQLConnection("Select_Environment_Types", null);
            string message = resultEnvironmentTypes.Item1;
            DataTable environmentTypeTable = resultEnvironmentTypes.Item2;

            return new SelectList(environmentTypeTable.AsDataView(), "ID", "Name");
        }

        //For dropdowns
        public SelectList GetEnvironmentsList()
        {
            var resultServerTypes = dbObject.SQLConnection("Select_Environments", null);
            string message = resultServerTypes.Item1;
            DataTable ServerTypeTable = resultServerTypes.Item2;

            return new SelectList(ServerTypeTable.AsDataView(), "ID", "Name");
        }

        //Gets full result set
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
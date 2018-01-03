using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectOffice.Controllers;
using System.Data;
using System.Web.UI.WebControls;

namespace ProjectOffice.Models.Forms.ApplicationList
{
    public class ApplicationListModel
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

        public static DataTable GetEnvironments()
        {
            var resultEnvironments = DBClassController.SQLConnection("Select_Environments", "1");
            string message = resultEnvironments.Item1;
            DataTable environmentsTable = resultEnvironments.Item2;

            return environmentsTable;
        }
    }
}
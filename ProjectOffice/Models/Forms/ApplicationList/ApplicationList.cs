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




namespace ProjectOffice.Models.Forms.ApplicationList
{
    public class ApplicationListModel
    {
        public string ID { get; set; }
        public string Application_ID { get; set; }
        public string Support_Company_ID { get; set; }
        public string Server_ID { get; set; }
        public string Environment_Type_ID { get; set; }
        public string Comment { get; set; }
        public string Created { get; set; }
        public string Deleted { get; set; }

        public JsonResult GetEnvironments()
        {
            string message = "";
            string jsonResult = "";
            DataTable payload = null;

            var resultEnvironments = DBClassController.SQLConnection("Select_Environments", "1");
            message = resultEnvironments.Item1;
            payload = resultEnvironments.Item2;

            jsonResult = DBClassController.BuildDataTableToJson(payload);

            var jsonResponse = new JsonResult();
            jsonResponse.Data = new { results = jsonResult };
            jsonResponse.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            Debug.Write(jsonResponse);
            return jsonResponse;
        }
    }

}
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
        public string Environment_ID { get; set; }
        public string Application_ID { get; set; }
        public string Support_Company_ID { get; set; }
        public string Server_ID { get; set; }
        public string Environment_Type_ID { get; set; }
        public string Comment { get; set; }
        public string Created { get; set; }
        public string Deleted { get; set; }
        public string Order { get; set; }
        public string Offset { get; set; }
        public string Sort { get; set; }
        public string Limit { get; set; }
        public string Search { get; set; }
    }

}
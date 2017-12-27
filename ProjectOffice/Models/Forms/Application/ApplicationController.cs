using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectOffice.Models.Forms.Application
{
    public class ApplicationModel
    {
        public string ORDER_BY { get; set; }
        public int? Get_All { get; set; }
        public int? ID { get; set; }
        public int? Support_Company_ID { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public SelectList Package_Type { get; set; }
        public string Comment { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
        public bool? Deleted { get; set; } = false;
    }
}
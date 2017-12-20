using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ProjectOffice.Models.Forms.SupportCompany
{
    public class SupportCompanyModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address_1 { get; set; }
        public string Address_2 { get; set; }
        public string Post_Code { get; set; }
        public Nullable<int> Tel { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Comment { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public bool Out_Of_Hours { get; set; }
        public bool Status { get; set; }
        public Nullable<bool> Deleted { get; set; }
    }
}
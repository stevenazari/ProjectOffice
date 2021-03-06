﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectOffice.Models.Forms.SoftwareCatalogue.SupportCompany
{
    public class SupportCompanyModel
    {
        public string ORDER_BY { get; set; }
        public int? Get_All { get; set; }
        public int? ID { get; set; }
        [Remote("SupportCompanyValidation", "SupportCompany", ErrorMessage = "Company name already exists", AdditionalFields = "Name")]
        public string Name { get; set; }
        public string Address_1 { get; set; }
        public string Address_2 { get; set; }
        public string Post_Code { get; set; }
        public string Tel { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }
        public string Website { get; set; }
        public string Comment { get; set; }
        public bool Out_Of_Hours { get; set; } = false;
        public string Created { get; set; } = DateTime.Now.ToString("yyyy-MM-dd h:mm tt");
        public bool Status { get; set; } = true;
        public bool? Deleted { get; set; } = false;
    }
}
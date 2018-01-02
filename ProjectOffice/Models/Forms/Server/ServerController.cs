using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectOffice.Controllers;
using System.Data;
using System.Web.UI.WebControls;

namespace ProjectOffice.Models.Forms.Server
{
    public class ServerModel
    {
        public string ORDER_BY { get; set; }
        public int? Get_All { get; set; }
        public int? ID { get; set; }
        public string Name { get; set; }
        public string IP_Address { get; set; }
        public int Operating_System_ID { get; set; }
        public int Server_Type_ID { get; set; }
        public string Comment { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public bool? Status { get; set; }
        public bool? Deleted { get; set; }

        public static SelectList GetOperatingSystems()
        {
            var resultOperatingSystems = DBClassController.SQLConnection("Select_Operating_Systems", null);
            string message = resultOperatingSystems.Item1;
            DataTable OSTable = resultOperatingSystems.Item2;

            return new SelectList(OSTable.AsDataView(), "ID", "Name");
        }

        public static SelectList GetServerTypes()
        {
            var resultServerTypes = DBClassController.SQLConnection("Select_Server_Types", null);
            string message = resultServerTypes.Item1;
            DataTable ServerTypeTable = resultServerTypes.Item2;

            return new SelectList(ServerTypeTable.AsDataView(), "ID", "Name");
        }

    }
}
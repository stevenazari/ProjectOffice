using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectOffice.Controllers;
using System.Data;
using System.Web.UI.WebControls;

namespace ProjectOffice.Models.Forms.ServiceCatalogue.Server
{
    public class Create_Server_Model
    {
        public DBClassController dbObject = new DBClassController();

        public string ORDER_BY { get; set; }
        public int? Get_All { get; set; }
        public int? ID { get; set; }
        [Remote("ServerValidation", "Server", ErrorMessage = "Server already exists")]
        public string Name { get; set; }
        public string IP_Address { get; set; }
        public int Operating_Systems_ID { get; set; }
        public int Server_Types_ID { get; set; }
        public string Comment { get; set; }
        public string Created { get; set; }
        public bool? Status { get; set; }
        public bool? Deleted { get; set; }

        public SelectList GetOperatingSystems()
        {
            var resultOperatingSystems = dbObject.SQLConnection("Select_Operating_Systems", null);
            string message = resultOperatingSystems.Item1;
            DataTable OSTable = resultOperatingSystems.Item2;

            return new SelectList(OSTable.AsDataView(), "ID", "Name");
        }

        public SelectList GetServerTypes()
        {
            var resultServerTypes = dbObject.SQLConnection("Select_Server_Types", null);
            string message = resultServerTypes.Item1;
            DataTable ServerTypeTable = resultServerTypes.Item2;

            return new SelectList(ServerTypeTable.AsDataView(), "ID", "Name");
        }
    }

    public class Add_Server_Model
    {
        public DBClassController dbObject = new DBClassController();

        public int? Item_ID { get; set; }
        public int? Item_Type_ID { get; set; }
        public int? Parent_ID { get; set; }
        public int? Environment_ID { get; set; }

        public SelectList GetServerTypes()
        {
            var resultServerTypes = dbObject.SQLConnection("Select_Server_Types", null);
            string message = resultServerTypes.Item1;
            DataTable ServerTypeTable = resultServerTypes.Item2;

            return new SelectList(ServerTypeTable.AsDataView(), "ID", "Name");
        }

        public SelectList GetServersList(int Environment_ID, int Exclude)
        {
            string search = "0";
            string listID = "ID";

            if (Environment_ID > 0)
            {
                search = search + ", " + Environment_ID + ", " + Exclude;
            }

            if (Exclude == 0)
            {
                listID = "EI_ID";
            }

            var servers = dbObject.SQLConnection("Select_Servers_List", search);
            string message = servers.Item1;
            DataTable serverList = servers.Item2;

            return new SelectList(serverList.AsDataView(), listID, "Server_Name");
        }
    }
}
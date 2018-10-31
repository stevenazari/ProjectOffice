using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Reflection;
using System.Diagnostics;
using System.Linq;
using ProjectOffice.Models.Forms.ServiceCatalogue.Server;

namespace ProjectOffice.Controllers.Forms.ServiceCatalogue.Server
{
    public class ServerController : Controller
    {
        public DBClassController dbObject = new DBClassController();
        string message = "";
        string jsonResult = "";
        string procedureValues = "";
        DataTable payload = null;


        // GET: Server
        public ActionResult Create_Server()
        {
            ViewBag.Title = "Create Server";
            var model = new ProjectOffice.Models.Forms.ServiceCatalogue.Server.Create_Server_Model();

            return PartialView("~/Views/Forms/ServiceCatalogue/Server/Create_Server.cshtml", model);
        }

        [HttpPost]
        public JsonResult Create_Server_Submit(Create_Server_Model data)
        {
            procedureValues = dbObject.checkDataType(data);

            if (ModelState.IsValid)
            {
                var result = dbObject.SQLConnection("Insert_Server", procedureValues);
                message = result.Item1;
                payload = result.Item2;
            }
            else
            {
                var err = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));

                message = "Please provide required fields: " + err;
            }

            jsonResult = dbObject.BuildDataTableToJson(payload);

            var jsonResponse = new { message = message, results = jsonResult };
            return Json(jsonResponse, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Add_Server(int Environment_ID)
        {
            var model = new ProjectOffice.Models.Forms.ServiceCatalogue.Server.Add_Server_Model();

            ViewBag.Environment_ID = Environment_ID;
            ViewBag.Server_List = model.GetServersList(Environment_ID, 1);

            return PartialView("~/Views/Forms/ServiceCatalogue/Server/Add_Server.cshtml", model);
        }

        [HttpPost]
        public JsonResult Add_Server_Submit(Add_Server_Model data)
        {
            procedureValues = dbObject.checkDataType(data);

            if (ModelState.IsValid)
            {
                var result = dbObject.SQLConnection("Insert_Environment_Item", procedureValues);
                message = result.Item1;
                payload = result.Item2;
            }
            else
            {
                var err = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));

                message = "Please provide required fields: " + err;
            }

            jsonResult = dbObject.BuildDataTableToJson(payload);

            var jsonResponse = new { message = message, results = jsonResult };
            return Json(jsonResponse, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Server_Details(bool Server_Check, DataRow row, DataTable Environment_Details)
        {
            var model = new ProjectOffice.Models.Forms.ServiceCatalogue.Environment.Delete_Environment_Item_Model();

            DataView Application_List = new DataView(Environment_Details);
            Application_List.RowFilter = "Item_Type_ID = 1";
            //Application_List.RowFilter = "Parent_ID = " + row["EI_ID"];

            ViewBag.row = row;
            ViewBag.Application_List = Application_List;
            ViewBag.Environment_ID = row["Environment_ID"];
            ViewBag.Server_Check = Server_Check;


            return PartialView("~/Views/Forms/ServiceCatalogue/Server/Server_Details.cshtml", model);
        }

        public ActionResult ServerValidation(string Name)
        {
            //procedureValues = dbObject.checkDataType(supportCompany);

            var result = dbObject.SQLConnection("Select_Servers", "@SEARCH = 1, @NAME = N'" + Name + "'");
            message = result.Item1;
            payload = result.Item2;
            bool exists = false;

            if (payload.Rows.Count > 0)
            {
                return HttpNotFound("Server already exists");
            }

            return Json(exists, JsonRequestBehavior.AllowGet);
        }

    }
}
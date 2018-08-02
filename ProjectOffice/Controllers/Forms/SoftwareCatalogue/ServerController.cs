using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Reflection;
using System.Diagnostics;
using System.Linq;
using ProjectOffice.Models.Forms.SoftwareCatalogue.Server;

namespace ProjectOffice.Controllers.Forms.SoftwareCatalogue.Server
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
            var model = new ProjectOffice.Models.Forms.SoftwareCatalogue.Server.Create_Server_Model();

            return PartialView("~/Views/Forms/SoftwareCatalogue/Server/Create_Server.cshtml", model);
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
            var model = new ProjectOffice.Models.Forms.SoftwareCatalogue.Server.Add_Server_Model();

            ViewBag.Environment_ID = Environment_ID;
            ViewBag.Server_List = model.GetServersList(Environment_ID, 1);

            return PartialView("~/Views/Forms/SoftwareCatalogue/Server/Add_Server.cshtml", model);
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

        public ActionResult Server_Details(DataRow row)
        {
            var model = new ProjectOffice.Models.Forms.SoftwareCatalogue.Environment.Delete_Environment_Item_Model();
            ViewBag.row = row;
            return PartialView("~/Views/Forms/SoftwareCatalogue/Server/Server_Details.cshtml", model);
        }
    }
}
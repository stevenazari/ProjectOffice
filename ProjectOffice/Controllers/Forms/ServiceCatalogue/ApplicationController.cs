﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Reflection;
using System.Diagnostics;
using System.Linq;
using System.Dynamic;
using ProjectOffice.Models.Forms.ServiceCatalogue.Application;
using ProjectOffice.Models.Forms.ServiceCatalogue.Server;

namespace ProjectOffice.Controllers.Forms.ServiceCatalogue.Application
{
    public class ApplicationController : Controller
    {
        public DBClassController dbObject = new DBClassController();

        string message = "";
        string jsonResult = "";
        string procedureValues = "";
        DataTable payload = null;

        // GET: Application
        public ActionResult Create_Application()
        {
            ViewBag.Title = "Add Application";
            var model = new ProjectOffice.Models.Forms.ServiceCatalogue.Application.Create_Application_Model();
            return PartialView("~/Views/Forms/ServiceCatalogue/Application/Create_Application.cshtml", model);
        }

        [HttpPost]
        public JsonResult Create_Application(Create_Application_Model data)
        {
            procedureValues = dbObject.checkDataType(data);

            if (ModelState.IsValid)
            {
                var result = dbObject.SQLConnection("Insert_Applications", procedureValues);
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
        public ActionResult Add_Application(int Environment_ID)
        {
            Add_Server_Model ServerObject = new ProjectOffice.Models.Forms.ServiceCatalogue.Server.Add_Server_Model();
            var model = new ProjectOffice.Models.Forms.ServiceCatalogue.Application.Add_Application_Model();

            ViewBag.Environment_ID = Environment_ID;
            ViewBag.Add_Application = GetApplications();
            ViewBag.Server_List = ServerObject.GetServersList(Environment_ID, 0);
            
            return PartialView("~/Views/Forms/ServiceCatalogue/Application/Add_Application.cshtml", model);
        }

        [HttpPost]
        public JsonResult Add_Application_Submit(Add_Application_Model data)
        {
            if (data.Parent_ID == null)
            {
                data.Parent_ID = data.Environment_ID;
            }

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

        public SelectList GetApplications()
        {
            var resultApplicationList = dbObject.SQLConnection("Select_Application_List", null);
            string message = resultApplicationList.Item1;
            DataTable applicationListTable = resultApplicationList.Item2;

            return new SelectList(applicationListTable.AsDataView(), "ID", "Application_Name");
        }

        public ActionResult Application_Details(bool Application_Check, DataRow row, int Environment_ID)
        {
            var model = new ProjectOffice.Models.Forms.ServiceCatalogue.Environment.Delete_Environment_Item_Model();
            ViewBag.Row = row;
            ViewBag.Environment_ID = Environment_ID;
            ViewBag.Application_Check = Application_Check;

            return PartialView("~/Views/Forms/ServiceCatalogue/Application/Application_Details.cshtml", model);
        }
    }
}
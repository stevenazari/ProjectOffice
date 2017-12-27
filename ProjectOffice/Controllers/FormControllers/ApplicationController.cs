using System;
using System.Web.Mvc;
using ProjectOffice.Controllers;
using System.Data;
using System.Reflection;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using ProjectOffice.Models.Forms.Application;



namespace ProjectOffice.Controllers.FormControllers
{
    public class ApplicationController : Controller
    {
        // GET: Application
        public ActionResult Index()
        {
            return View();
        }

        private void Get_Package_Type()
        {
            DataTable payload = null;
            string message = "";

            if (ModelState.IsValid)
            {
                var result = DBClassController.SQLConnection("Select_Application_Package_Types", null);
                message = result.Item1;
                payload = result.Item2;

                ddlSubject.DataSource = payload;
                ddlSubject.DataTextField = "Name";
                ddlSubject.DataValueField = "Version";
                ddlSubject.DataBind();

                Package_Type.Items.Insert(0, new ListItem("Select Package Type", "0"));
                Debug.WriteLine("Message: " + message + "Payload: " + payload); 
            }
            else
            {
                Debug.WriteLine("ModelState Failed ");
                message = "Please provide required fields.";
            }
        }
    }
}
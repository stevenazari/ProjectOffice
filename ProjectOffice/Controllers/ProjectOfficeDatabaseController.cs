﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Reflection;
using System.Text;
using System.Collections;
using System.Collections.Specialized;
using System.Diagnostics;
using Newtonsoft.Json;


namespace ProjectOffice.Controllers
{
    public class DBClassController : Controller
    {
        // GET: ProjectOfficeDB
        public ActionResult Index()
        {
            return View();
        }

        public static Tuple<string, DataTable> SQLConnection(string StoredProcedure, string values)
        {
            string message = "";
            string procedure = "EXEC " + StoredProcedure + " " + values;
            //Debug.Write(procedure + " END");
            DataTable results = new DataTable(StoredProcedure);

            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ToString()))
                using (SqlCommand query = new SqlCommand(procedure, connection))
                {
                    SqlDataAdapter data = new SqlDataAdapter(query);
                    connection.Open();
                    data.Fill(results);
                    connection.Close();

                    message = "Success";
                }

            }
            catch (Exception ex)
            {
                message = "Error running query (" + StoredProcedure + ") " + ex;
            }

            return Tuple.Create(message, results);
        }

        public static string BuildDataTableToJson(DataTable colVal)
        {
            string JSONresult;
            JSONresult = JsonConvert.SerializeObject(colVal);

            return JSONresult;
        }

        public static string FirstCharToUpper(string input)
        {
            switch (input)
            {
                case null: return input;
                case "": return input;
                default: return input.First().ToString().ToUpper() + input.Substring(1);
            }
        }
    }
}
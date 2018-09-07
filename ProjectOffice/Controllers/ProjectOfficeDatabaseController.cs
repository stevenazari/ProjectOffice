using System;
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

        public Tuple<string, DataTable> SQLConnection(string StoredProcedure, string values)
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
                string error = ex.ToString();

                if (error.Contains("Violation of UNIQUE KEY") == true)
                {
                    error = "object already exists";
                } else if (error.Contains("Error converting data type") == true)
                {
                    error = "A column has the the wrong format";
                } else
                {
                    //Cater for next friendly error message
                }

                //message = "Error running query (" + StoredProcedure + ") " + ex; //Detailed error message
                message = "Error: " + error;
            }

            return Tuple.Create(message, results);
        }

        public string BuildDataTableToJson(DataTable colVal)
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
        public string checkDataType(object data)
        {
            string returnValue = "";
            Type type = data.GetType();
            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {

                if (property.GetValue(data, null) is null)
                {
                    returnValue += "@" + property.Name + " = " + "NULL, ";
                }
                else if (property.GetValue(data, null) is string)
                {
                    returnValue += "@" + property.Name + " = '" + property.GetValue(data, null) + "', ";
                }
                else if (property.GetValue(data, null) is int)
                {
                    returnValue += "@" + property.Name + " = " + property.GetValue(data, null) + ", ";
                }
                else if (property.GetValue(data, null) is bool)
                {
                    returnValue += "@" + property.Name + " = " + property.GetValue(data, null) + ", ";
                }
                else if (property.GetValue(data, null) is DateTime)
                {
                    returnValue += "@" + property.Name + " = '" + property.GetValue(data, null) + "', ";
                }
                else
                {
                    returnValue += "@" + property.Name + " = '" + property.GetValue(data, null) + "', ";
                }
            }
            returnValue = returnValue.Remove(returnValue.Length - 2);

            return returnValue;
        }
    }
}
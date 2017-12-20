using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Reflection;


namespace ProjectOffice.Controllers
{
    public class DBClassController : Controller
    {
        // GET: ProjectOfficeDB
        public ActionResult Index()
        {
            return View();
        }

        public string SQLConnection(string StoredProcedure, object colVal)
        {
            string message = "";

            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectOffice"].ToString());
                con.Open();
                SqlCommand cmd = new SqlCommand(StoredProcedure, con);
                cmd.CommandType = CommandType.StoredProcedure;

                PropertyInfo[] columns = colVal.GetType().GetProperties();

                foreach (PropertyInfo column in colVal.GetType().GetProperties())
                {
                    cmd.Parameters.AddWithValue("@" + column.Name, column.GetValue(columns, null));
                }

                cmd.ExecuteNonQuery();
                con.Close();

                message = "Success";
            }
            catch (Exception ex)
            {
                message = "Error adding support company (" + ex + ")";
            }

            return message;
        }
    }
}
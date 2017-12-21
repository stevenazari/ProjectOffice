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

namespace ProjectOffice.Controllers
{
    public class DBClassController : Controller
    {
        // GET: ProjectOfficeDB
        public ActionResult Index()
        {
            return View();
        }

        public static Tuple<string, DataTable> SQLConnection(string StoredProcedure, Dictionary<string,string> colVal)
        {
            DBClassController dbClass = new DBClassController();
            DataTable dataTable = new DataTable();
            string message = "";
            string Query = dbClass.BuildStoredProcedure(StoredProcedure, colVal);

            try
            {
                using (SqlDataAdapter connection = new SqlDataAdapter(Query, ConfigurationManager.ConnectionStrings["ProjectOffice"].ToString()))
                connection.Fill(dataTable);
                
                message = "Success";
            }
            catch (Exception ex)
            {
                message = "Error running query (" + Query + ") " + ex;
            }

            return Tuple.Create(message, dataTable);
        }

        public string BuildStoredProcedure(string StoredProcedure, Dictionary<string, string> colVal)
        {
            string procedure = "EXEC " + StoredProcedure + " ";

            foreach (KeyValuePair<string,string> value in colVal)
            {
                procedure += "@" + value.Key + " = " + value.Value + " ";
            }

            return procedure;
        }

        public static string BuildDataTableToJson(DataTable colVal)
        {
            DataSet ds = new DataSet();
            ds.Merge(colVal);
            StringBuilder JsonString = new StringBuilder();

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                JsonString.Append("[");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    JsonString.Append("{");
                    for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                    {
                        if (j < ds.Tables[0].Columns.Count - 1)
                        {
                            JsonString.Append("\"" + ds.Tables[0].Columns[j].ColumnName.ToString() + "\":" + "\"" + ds.Tables[0].Rows[i][j].ToString() + "\",");
                        }
                        else if (j == ds.Tables[0].Columns.Count - 1)
                        {
                            JsonString.Append("\"" + ds.Tables[0].Columns[j].ColumnName.ToString() + "\":" + "\"" + ds.Tables[0].Rows[i][j].ToString() + "\"");
                        }
                    }
                    if (i == ds.Tables[0].Rows.Count - 1)
                    {
                        JsonString.Append("}");
                    }
                    else
                    {
                        JsonString.Append("},");
                    }
                }
                JsonString.Append("]");
                return JsonString.ToString();
            }
            else
            {
                return null;
            }
        }
    }
}
using HRMS.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HRMS.Repository
{
    public class HrmsAccessoireRepo
    {
        SqlConnection conn = null;

        #region[Constructor-Using Connection-string]
        public HrmsAccessoireRepo()
        {


            string connStr = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            conn = new SqlConnection(connStr);

        }

        #endregion

        public int SaveAccessoire(HrmsAccessoireViewModel model)

        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ASSESSIRE_SP"; // Store procediure name
            cmd.Parameters.Add("@ASSESSIRE_NAME", SqlDbType.NVarChar).Value = model.Accessoire_Name;
            cmd.Parameters.Add("@ASSESSIRE_TYPE", SqlDbType.NVarChar).Value = model.Accessoire_Type;
            cmd.Parameters.Add("@EXPANCE_DATE", SqlDbType.DateTime).Value = model.Expence_Date;


            cmd.Connection = conn;
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();

                conn.Close();
            }

            catch (Exception ex)
            {
                throw ex;
            }
            return 0;

        }
    }
}
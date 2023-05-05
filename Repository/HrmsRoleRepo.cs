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
    public class HrmsRoleRepo
    {
        SqlConnection conn = null;

        #region[Constructor-Using Connection-string]
        public HrmsRoleRepo()
        {


            string connStr = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            conn = new SqlConnection(connStr);

        }

        #endregion


        public int SaveRole(HrmsRoleViewModel model)

        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ROLE_SP"; // Store procediure name
            cmd.Parameters.Add("@ROLE_TYPE", SqlDbType.NVarChar).Value = model.Role_type;
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
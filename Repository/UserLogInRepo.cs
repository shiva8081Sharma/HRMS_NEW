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
    public class UserLogInRepo
    {
        SqlConnection conn = null;

        #region[Constructor-Using-Connection-string]

        public UserLogInRepo()
        
        {
            string connStr = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            conn = new SqlConnection(connStr);
        }

        #endregion
        public int UserLogIn( MstUserRegistrationViewModel model)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "User_Login"; // Store procediure name
            cmd.Parameters.Add("@Empid", SqlDbType.VarChar).Value = model.UserId;
            cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = model.Password;
            //cmd.Parameters["@Status"].Direction = ParameterDirection.Output;
            SqlParameter oblogin = new SqlParameter();
            cmd.Connection = conn;
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
             {
                int i = Convert.ToInt32(reader["status"]);
                conn.Close();
                return i;
            }
            else

             return 0; 
        }

    }
}
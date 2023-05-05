using HRMS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace HRMS.Repository
{
    public class UserRegistrationRepo
    {
        SqlConnection conn = null;


        #region[Constructor-Using Connection-string]
        public UserRegistrationRepo() 
        {

            string connStr = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            conn = new SqlConnection(connStr);
        }

        #endregion
        public int UserRegistrationSaveData(MstUserRegistrationViewModel model)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "UserRegistration"; // Store procediure name
            cmd.Parameters.Add("@UserId", SqlDbType.VarChar).Value = model.UserId;
            cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = model.FirstName;
            cmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = model.LastName;
            cmd.Parameters.Add("@EmailId", SqlDbType.VarChar).Value = model.Email;
            cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = model.Address;
            cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = model.Password;
            cmd.Parameters.Add("@ERROR", SqlDbType.VarChar, 100).Value = model.ERROR;
            cmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
            cmd.Connection = conn;
            conn.Open();
            cmd.ExecuteNonQuery();
            string result = cmd.Parameters["@ERROR"].Value.ToString();

            if (result.Contains("Already Exists"))
            {
                conn.Close();
                return 0;
            }
            else
            {
                conn.Close();
                return 1;
            }
        }

    }
}
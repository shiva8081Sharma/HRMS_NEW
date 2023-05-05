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
    public class UserAttendanceRepo
    {
        SqlConnection conn = null;

        public UserAttendanceRepo()
        {

            string connStr = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            conn = new SqlConnection(connStr);
        }
        #region[This-Repo-Method use for UserAttendanceSaveData...]
        public int UserAttendanceSaveData(string UserId,string InTime)
          {
       
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "UserAttendance"; // Store procediure name
            cmd.Parameters.Add("@UserId", SqlDbType.VarChar).Value = UserId;
            cmd.Parameters.Add("@InTime", SqlDbType.VarChar).Value = InTime;
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
        #endregion


        #region[This-Repo-Method use for GetUserAttendanceTime... ]
        public DateTime GetUserAttendanceTime(string UserId)
        {
            SqlCommand cmd = new SqlCommand();
            DateTime Date=System.DateTime.Now;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetAttendanceTime"; // Store procediure name
            cmd.Parameters.Add("@UserId", SqlDbType.VarChar).Value = UserId;
            cmd.Connection = conn;
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Date = Convert.ToDateTime(reader["InTime"]);
                conn.Close();
                return Date;
            }
            else
               
            return Date;   
        }
        #endregion




        #region[This -Repo-Method use for Send Attendace for Approvel]

        public int SaveApprovelAttendance(string EMP_ID, DateTime InTime,string In_out,string Remark)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ATTENDANCE_APPROVEL_SP"; // Store procediure name
            cmd.Parameters.Add("@EMP_ID", SqlDbType.VarChar).Value = EMP_ID;
            cmd.Parameters.Add("@IN_TIME", SqlDbType.DateTime).Value = InTime;
            cmd.Parameters.Add("@In_Out", SqlDbType.VarChar).Value = In_out;
            cmd.Parameters.Add("@Remark ", SqlDbType.VarChar).Value = Remark;
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
        #endregion



    }


}

    

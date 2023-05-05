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
    public class UserLeaveRepo
    {
        SqlConnection conn = null;

        #region[Constructor-Using Connection-string]
        public UserLeaveRepo()
        {


            string connStr = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            conn = new SqlConnection(connStr);

        }

        #endregion


        public int SaveLeave(HrmsLeaveViewModel model)

        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "LEAVE_SP"; // Store procediure name
            cmd.Parameters.Add("@LEAVE_TYPE", SqlDbType.NVarChar).Value = model.TYPE_LEAVE;


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

        public int SaveEmpApplyLeave(HrmsLeaveViewModel model)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.CommandText = "EMP_LEAVE_SP";// Store procediure name
            cmd.Parameters.Add("@EMP_ID", SqlDbType.VarChar).Value = model.Emp_Id;
            cmd.Parameters.Add("@TYPE_LEAVE",SqlDbType.VarChar).Value = model.TYPE_LEAVE;
            cmd.Parameters.Add("@AAPLIED_TOTAL_LEAVE", SqlDbType.Int).Value = model.APPLIED_TOTAL_LEAVE;
            cmd.Parameters.Add("@REASON_FOR_LEAVE", SqlDbType.VarChar).Value = model.REASON_FOR_LEAVE;
            cmd.Parameters.Add("@LEAVE_FROM_DATE ", SqlDbType.Date).Value = model.LEAVE_FROM_DATE;
            cmd.Parameters.Add("@LEAVE_TO_DATE ", SqlDbType.Date).Value = model.LEAVE_TO_DATE;
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





        #region[This-Repo-Method use for GetLocationDropDwon... ]
        public List<HrmsLeaveViewModel> GetLeaveDropDwon()
        {


            List<HrmsLeaveViewModel> hrmsLeaveViewModels = new List<HrmsLeaveViewModel>();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GET_LEAVE_DROPDWON_SP"; // Store procediure name
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            cmd.Connection = conn;
            conn.Open();
            sd.Fill(dt);
            conn.Close();
            foreach (DataRow dr in dt.Rows)
            {
                hrmsLeaveViewModels.Add(
                    new HrmsLeaveViewModel
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        TYPE_LEAVE = Convert.ToString(dr["Leave_Type"]),

                    });
            }

            return hrmsLeaveViewModels;



        }

        #endregion




    }

}


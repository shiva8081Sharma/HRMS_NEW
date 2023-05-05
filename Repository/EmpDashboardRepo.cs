using HRMS.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace HRMS.Repository
{
    public class EmpDashboardRepo
    {

        SqlConnection conn = null;

        #region[Constructor-Using Connection-string]
        public EmpDashboardRepo()
        {
            string connStr = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            conn = new SqlConnection(connStr);
        }

        #endregion




        #region[This-Repo-Method use for GetAttendanceList... ]
        public List<HrmsUserAttendanceViewModel> GetAttendanceList(HrmsUserAttendanceViewModel model)
        {
            List<HrmsUserAttendanceViewModel> hrmsUserAttendanceViewModels = new List<HrmsUserAttendanceViewModel>();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GET_EMP_DASHBOARD_ATTENDANCE"; // Store procediure name
            cmd.Parameters.Add("@Emp_Id", SqlDbType.NVarChar).Value = model.EMP_ID;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            cmd.Connection = conn;
            conn.Open();
            sd.Fill(dt);
            conn.Close();
            foreach (DataRow dr in dt.Rows)
            {
                hrmsUserAttendanceViewModels.Add(
                    new HrmsUserAttendanceViewModel
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        EMP_ID = Convert.ToString(dr["EMP_ID"]),
                        Remark = Convert.ToString(dr["Remark"]),
                        IN_TIME = Convert.ToDateTime(dr["IN_TIME"]),
                        OUT_TIME = Convert.ToDateTime(dr["OUT_TIME"]),
                        Is_Rejected = Convert.ToBoolean(dr["Is_Rejected"]),
                        Is_Approved = Convert.ToBoolean(dr["Is_Approved"]),
                        Type= Convert.ToString(dr["Type"]),



                    });
                    }

            return hrmsUserAttendanceViewModels;

        }

        #endregion

        public List<HrmsUserAttendanceViewModel> GetAttendanceListbyId(HrmsUserAttendanceViewModel model)
         {
            List<HrmsUserAttendanceViewModel> hrmsUserAttendanceViewModels = new List<HrmsUserAttendanceViewModel>();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GET_APPROVEL_BY_ID_SP"; // Store procediure name
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = model.Id;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            cmd.Connection = conn;
            conn.Open();
            sd.Fill(dt);
            conn.Close();
            foreach (DataRow dr in dt.Rows)
            {
                hrmsUserAttendanceViewModels.Add(
                    new HrmsUserAttendanceViewModel
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        EMP_ID = Convert.ToString(dr["EMP_ID"]),
                        Remark = Convert.ToString(dr["Remark"]),
                        IN_TIME = Convert.ToDateTime(dr["IN_TIME"]),
                        OUT_TIME = Convert.ToDateTime(dr["OUT_TIME"]),
                        Is_Rejected = Convert.ToBoolean(dr["Is_Rejected"]),
                        Is_Approved = Convert.ToBoolean(dr["Is_Approved"]),
                        Type = Convert.ToString(dr["Type"]),

                    });
            }
            return hrmsUserAttendanceViewModels;

        }

        #region[This-Repo-Method use for UserAttendanceSaveData...]
        public int Delete_Approvel_Attendace(string Emp_Id, int Id)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "DELETE_APPROVEL_ATTENDANCE"; // Store procediure name
            cmd.Parameters.Add("@EMP_ID", SqlDbType.VarChar).Value = Emp_Id;
            cmd.Parameters.Add("@ID ", SqlDbType.Int).Value = Id;
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



        #region[This-Repo-Method use for AcceptApprovelAttendace...]
        public int Accept_Approvel_Attendace(string Emp_Id, int Id, HrmsUserAttendanceViewModel model)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ACCEPT_APPROVEL_SP"; // Store procediure name
            cmd.Parameters.Add("@EMP_ID", SqlDbType.VarChar).Value = Emp_Id;
            cmd.Parameters.Add("@ID ", SqlDbType.Int).Value = Id;
            cmd.Parameters.Add("@Manager_Remark", SqlDbType.VarChar).Value = model.Manager_Remark;
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




        #region[This-Repo-Method use for AcceptApprovelAttendace...]
        public int Reject_Approvel_Attendace(string Emp_Id, int Id)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "REJECT_APPROVEL_SP"; // Store procediure name
            cmd.Parameters.Add("@EMP_ID", SqlDbType.VarChar).Value = Emp_Id;
            cmd.Parameters.Add("@ID ", SqlDbType.Int).Value = Id;
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




        #region[This-Repo-Method use for GetLeaveList... ]
        public List<HrmsLeaveViewModel> GetLeaveList(HrmsLeaveViewModel model)
        {
            List<HrmsLeaveViewModel> HrmsLeaveViewModel = new List<HrmsLeaveViewModel>();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GET_EMP_DASHBOARD_LEAVE"; // Store procediure name
            cmd.Parameters.Add("@Emp_Id", SqlDbType.NVarChar).Value = model.Emp_Id;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            cmd.Connection = conn;
            conn.Open();
            sd.Fill(dt);
            conn.Close();
            foreach (DataRow dr in dt.Rows)
            {
                HrmsLeaveViewModel.Add(
                    new HrmsLeaveViewModel
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Emp_Id = Convert.ToString(dr["EMP_ID"]),
                        TYPE_LEAVE = Convert.ToString(dr["TYPE_LEAVE"]),
                        APPLIED_TOTAL_LEAVE = Convert.ToInt32(dr["APPLIED_TOTAL_LEAVE"]),
                        LEAVE_TO_DATE = Convert.ToDateTime(dr["LEAVE_TO_DATE"]),
                        LEAVE_FROM_DATE = Convert.ToDateTime(dr["LEAVE_FROM_DATE"]),
                        REASON_FOR_LEAVE = Convert.ToString(dr["REASON_FOR_LEAVE"]),
                    });
            }
            return HrmsLeaveViewModel;

        }

        #endregion


        public List<HrmsLeaveViewModel> GetLeaveListbyId(HrmsLeaveViewModel model)
        {
            List<HrmsLeaveViewModel> HrmsLeaveViewModel = new List<HrmsLeaveViewModel>();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GET_EMP_LEAVE_ById"; // Store procediure name
            cmd.Parameters.Add("@ID", SqlDbType.NVarChar).Value = model.Id;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            cmd.Connection = conn;
            conn.Open();
            sd.Fill(dt);
            conn.Close();
            foreach (DataRow dr in dt.Rows)
            {
                HrmsLeaveViewModel.Add(
                    new HrmsLeaveViewModel
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Emp_Id = Convert.ToString(dr["EMP_ID"]),
                        TYPE_LEAVE = Convert.ToString(dr["TYPE_LEAVE"]),
                        APPLIED_TOTAL_LEAVE = Convert.ToInt32(dr["APPLIED_TOTAL_LEAVE"]),
                        LEAVE_TO_DATE = Convert.ToDateTime(dr["LEAVE_TO_DATE"]),
                        LEAVE_FROM_DATE = Convert.ToDateTime(dr["LEAVE_FROM_DATE"]),
                        REASON_FOR_LEAVE = Convert.ToString(dr["REASON_FOR_LEAVE"]),
                    });
            }
            return HrmsLeaveViewModel;


        }




    }





}
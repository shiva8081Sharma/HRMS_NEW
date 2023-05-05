using HRMS.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Web;

namespace HRMS.Repository
{
    public class EmployeeDetailsRepo
    {
        SqlConnection conn = null;

        #region[Constructor-Using Connection-string]
        public EmployeeDetailsRepo()
        {


            string connStr = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            conn = new SqlConnection(connStr);

        }

        #endregion

        public int SaveEmployeeDetails(HrmsEmployeeDetailsViewModel model)

        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "EMPLOYEE_DETAILS_SP"; // Store procediure name
            cmd.Parameters.Add("@FIRST_NAME", SqlDbType.NVarChar).Value = model.First_Name;
            cmd.Parameters.Add("@LAST_NAME ", SqlDbType.NVarChar).Value = model.Last_Name;
            cmd.Parameters.Add("@Gender ", SqlDbType.NVarChar).Value = model.Gender;
            cmd.Parameters.Add("@Emp_Dob  ", SqlDbType.Date).Value = model.Dob;
            cmd.Parameters.Add("@FATHER_NAME", SqlDbType.NVarChar).Value = model.Father_Name;
            cmd.Parameters.Add("@Date_of_JOINING", SqlDbType.Date).Value = model.Date_of_joining;
            cmd.Parameters.Add("@LOCATION_ID ", SqlDbType.Int).Value = model.Location_id;
            cmd.Parameters.Add("@MOBILE_NO ", SqlDbType.NVarChar).Value = model.Mobile_No;
            cmd.Parameters.Add("@ALTERNATE_No  ", SqlDbType.NVarChar).Value = model.Alternate_No;
            cmd.Parameters.Add("@CONTACT_MANAGER_ID ", SqlDbType.Int).Value = model.Contact_Manager_id;
            cmd.Parameters.Add("@DESIGATION_ID ", SqlDbType.Int).Value = model.Degistation_id;
            cmd.Parameters.Add("@TOTAL_LEAVE ", SqlDbType.Int).Value = model.Total_Leave;
            cmd.Parameters.Add("@DATE_OF_RELEAVE", SqlDbType.Date).Value = model.Date_of_Releave;
            cmd.Parameters.Add("@CURRENT_ADDRESS ", SqlDbType.NVarChar).Value = model.Current_Address;
            cmd.Parameters.Add("@EMAIL_ID  ", SqlDbType.NVarChar).Value = model.Email_Id;
            cmd.Parameters.Add("@ROLE_ID ", SqlDbType.NVarChar).Value = model.Role_Id;
            cmd.Parameters.Add("@NOM_NAME ", SqlDbType.NVarChar).Value = model.Nom_Name;
            cmd.Parameters.Add("@NOM_SHARE ", SqlDbType.NVarChar).Value = model.Nom_Share;
            cmd.Parameters.Add("@RELATION_WITH_EMP  ", SqlDbType.NVarChar).Value = model.Relation_with_Emp;
            cmd.Parameters.Add("@NOM_AADHAR_NUMBER ", SqlDbType.Int).Value = model.Nom_Aadhar_No;
            cmd.Parameters.Add("@NOM_PAN_CARD ", SqlDbType.NVarChar).Value = model.Nom_Pan_Card_No;
            cmd.Parameters.Add("@NOM_DOB ", SqlDbType.Date).Value = model.Nom_Dob;
            cmd.Parameters.Add("@IS_MINOR ", SqlDbType.Bit).Value = model.Nom_Is_Minor;
            cmd.Parameters.Add("@NOM_GUARDIAN_NAME  ", SqlDbType.NVarChar).Value = model.Nom_Guardion_Name;
            cmd.Parameters.Add("@APPROVAL_REJECTION_REMARK ", SqlDbType.NVarChar).Value = model.Nnom_Approver_Reark;
            cmd.Parameters.Add("@DOCUMENT_TYPE  ", SqlDbType.NVarChar).Value = model.Document_Type;
            cmd.Parameters.Add("@Emp_Img  ", SqlDbType.NVarChar).Value = model.EMP_PHOTO_Path;
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
        #region[This Method Use for DropDwon..........]

        public List<HrmsEmployeeDetailsViewModel> GetEmployeeDropDwon()
        {


            List<HrmsEmployeeDetailsViewModel> hrmsEmployeeDetailsViewModels = new List<HrmsEmployeeDetailsViewModel>();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GETEMPLOYEE_SP"; // Store procediure name
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            cmd.Connection = conn;
            conn.Open();
            sd.Fill(dt);
            conn.Close();
            foreach (DataRow dr in dt.Rows)
            {
                hrmsEmployeeDetailsViewModels.Add(
                    new HrmsEmployeeDetailsViewModel
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        First_Name = Convert.ToString(dr["First_Name"]),

                    });
            }

            return hrmsEmployeeDetailsViewModels;



        }
        #endregion

        #region[This-Repo-Method use for GetLocationDropDwon... ]
        public List<HrmsLocationViewModel> GetLocationDropDwon()
        {


            List<HrmsLocationViewModel> hrmsLocationViewModels = new List<HrmsLocationViewModel>();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GET_LOCATION_SP"; // Store procediure name
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            cmd.Connection = conn;
            conn.Open();
            sd.Fill(dt);
            conn.Close();
            foreach (DataRow dr in dt.Rows)
            {
                hrmsLocationViewModels.Add(
                    new HrmsLocationViewModel
                    {
                        LOCATION_ID = Convert.ToInt32(dr["Id"]),
                        Name = Convert.ToString(dr["Name"]),

                    });
            }

            return hrmsLocationViewModels;

        }

        #endregion



   

        #region[This-Repo-Method use for GetLocationDropDwon... ]
        public List<HrmsRoleViewModel> GetRoleDropDwon()
        {
            List<HrmsRoleViewModel> hrmsRoleViewModels = new List<HrmsRoleViewModel>();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GET_ROLE_DROPDWON"; // Store procediure name
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            cmd.Connection = conn;
            conn.Open();
            sd.Fill(dt);
            conn.Close();
            foreach (DataRow dr in dt.Rows)
            {
                hrmsRoleViewModels.Add(
                    new HrmsRoleViewModel
                    {
                        Role_Id = Convert.ToInt32(dr["Role_Id"]),
                        Role_type = Convert.ToString(dr["Role_type"]),

                    });
            }

            return hrmsRoleViewModels;

        }

        #endregion

    }

}

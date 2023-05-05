using HRMS.Models;
using HRMS.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace HRMS.Controllers
{
    public class HrmsEmpDashboardController : Controller
    {

        SqlConnection conn = null;
        public HrmsEmpDashboardController()
        {

            string connStr = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            conn = new SqlConnection(connStr);
        }
        #region[This Get-Method use for Show List on Dashboard]

        [HttpGet]
        public ActionResult GetAttendanceIndex()
        {
           
            EmpDashboardRepo empDashboardRepo = new EmpDashboardRepo();
            HrmsUserAttendanceViewModel model = new HrmsUserAttendanceViewModel();
            model.EMP_ID = Session["UserID"].ToString();
            model.hrmsUserAttendance=empDashboardRepo.GetAttendanceList(model);
            return View(model);
        }
        #endregion

        #region[This -Get-Method use for Open Click Popup on Approvel-Details]
        [HttpGet]
        public ActionResult _showList(int id)
        {
            EmpDashboardRepo empDashboardRepo = new EmpDashboardRepo();
            HrmsUserAttendanceViewModel model = new HrmsUserAttendanceViewModel();
            model.Id = id;
            //Here we can check if-else condition ........for login_id and Emp_Id......................
            model.LogIn_ID = Session["UserID"].ToString();
            model.hrmsUserAttendance = empDashboardRepo.GetAttendanceListbyId(model);
            return PartialView("_showList",model);
        }

        #endregion
           
        public ActionResult DeleteApprovel(string Emp_Id, int Id) 
        {
            EmpDashboardRepo empDashboardRepo = new EmpDashboardRepo();

            int i = empDashboardRepo.Delete_Approvel_Attendace(Emp_Id, Id);

            return RedirectToAction("GetAttendanceIndex", "HrmsEmpDashboard");

        }
        #region[This Method Use for Accept_Approvel_Attendance]
        
        public ActionResult AcceptApprovel(string Emp_Id,int Id, HrmsUserAttendanceViewModel model)
        {
            EmpDashboardRepo empDashboardRepo = new EmpDashboardRepo();

            int i = empDashboardRepo.Accept_Approvel_Attendace(Emp_Id, Id, model);

            return RedirectToAction("GetAttendanceIndex", "HrmsEmpDashboard");
        }
        #endregion

        #region[This Method Use for Reject_Approvel_Attendance]
        public ActionResult RejectApprovel(string Emp_Id, int Id)
        {
            EmpDashboardRepo empDashboardRepo = new EmpDashboardRepo();
            int i = empDashboardRepo.Reject_Approvel_Attendace(Emp_Id, Id);
            return RedirectToAction("GetAttendanceIndex", "HrmsEmpDashboard");
        }
        #endregion
         
        #region[This Get Method Use for Show Leave on Dashboard]
        [HttpGet]
        public ActionResult GetLeaveIndex()
        {

            EmpDashboardRepo empDashboardRepo = new EmpDashboardRepo();
            HrmsLeaveViewModel model = new HrmsLeaveViewModel();
            model.Emp_Id = Session["UserID"].ToString();
            model.hrmsLeaveViewModels = empDashboardRepo.GetLeaveList(model);
            return View(model);
        }

        #region[This -Get-Method use for Open Click Popup on Approvel-Details]
        [HttpGet]
        public ActionResult _showLeaveList(int id)
        {
            EmpDashboardRepo empDashboardRepo = new EmpDashboardRepo();
            HrmsLeaveViewModel model = new HrmsLeaveViewModel();
            model.Id = id;
            model.hrmsLeaveViewModels = empDashboardRepo.GetLeaveListbyId(model);
            return PartialView("_showLeaveList", model);
        }

        #endregion



        #endregion
    }
}
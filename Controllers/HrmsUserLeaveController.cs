using HRMS.Models;
using HRMS.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRMS.Controllers
{
    public class HrmsUserLeaveController : Controller
    {
        SqlConnection conn = null;


        public HrmsUserLeaveController() 
        {
            string connStr = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            conn = new SqlConnection(connStr);
        }
        [HttpGet]
        public PartialViewResult AddLeave()
        {
            HrmsLeaveViewModel model = new HrmsLeaveViewModel();
            return PartialView("_AddLeave");
        }

        [HttpPost]
        public ActionResult SaveLeave(HrmsLeaveViewModel model)
        {
            UserLeaveRepo userLeaveRepo = new UserLeaveRepo();  
            int i =userLeaveRepo.SaveLeave(model);
            return RedirectToAction("AttendanceIndex", "HrmUserAttendance");
        }

                              #region[This Method Use for Emp_Apply_Leave]
        [HttpGet]
        public ActionResult EmpApplyLeave()
        {
            HrmsLeaveViewModel model = new HrmsLeaveViewModel();
            UserLeaveRepo userLeaveRepo = new UserLeaveRepo();
            ViewBag.LeaveDropdwon = userLeaveRepo.GetLeaveDropDwon();
            model.Emp_Id = Session["UserID"].ToString();
            return PartialView("_ApplyLeave",model);
        }
        #endregion


        [HttpPost]
        public ActionResult SaveEmpApplyLeave(HrmsLeaveViewModel model)
        {
            UserLeaveRepo userLeaveRepo = new UserLeaveRepo();
            int i=userLeaveRepo.SaveEmpApplyLeave(model);
            return RedirectToAction("AttendanceIndex", "HrmUserAttendance");
        }
    }
}
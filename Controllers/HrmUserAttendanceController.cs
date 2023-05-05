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
    public class HrmUserAttendanceController : Controller
    {
       SqlConnection conn=null;
        #region[Constructor This-method- use for Connection-string]
        public HrmUserAttendanceController()
        {
            string connStr = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            conn = new SqlConnection(connStr);
        
        }
        #endregion

        #region[This Get-type Method Use for Attendance...]

        [HttpGet]
        public ActionResult AttendanceIndex()
        {
            HrmsUserAttendanceViewModel model = new HrmsUserAttendanceViewModel();
            #region[This -method -use for Show Attendance-Time]

            UserAttendanceRepo userAttendanceRepo = new UserAttendanceRepo();

            string UserId = Session["UserID"].ToString();
            var Date = userAttendanceRepo.GetUserAttendanceTime(UserId);
            var x = Date.ToString("hh:mm tt");
            var y = Date.ToShortDateString();
            if (y == "1/1/1900")
            {
                TempData["InTime"] = null;
            }
            else
                TempData["InTime"] = x;
            #endregion
            return View("AttendanceIndex", model);
        }


        #endregion


        #region[This Post-type Method Use for Save User-Attendance.....]
        public ActionResult SaveAttedance(string UserId ,string InTime)
        {
            //Here we are Create object of LogIn Repo

            UserAttendanceRepo userAttendanceRepo = new UserAttendanceRepo();

            var i = userAttendanceRepo.UserAttendanceSaveData(UserId, InTime);
            //var Date = userAttendanceRepo.GetUserAttendanceTime(UserId);
            //var x = Date.ToString("hh:mm tt");
            //ViewData["InTime"] = x;
          return RedirectToAction("AttendanceIndex");
        }
        #endregion

        [HttpGet]
        public PartialViewResult GetAttendanceApprovel(string ActionType)
        {
            HrmsUserAttendanceViewModel model = new HrmsUserAttendanceViewModel();
            //model.UserId = (Convert.ToInt32(Session["UserID"].ToString()));
            //model.UserId = Session["UserID"].ToString();
            model.EMP_ID = Session["UserID"].ToString();
           
            model.ActionType = ActionType;
            return PartialView("_GetAttendanceApprovel",model);
        }
        [HttpPost]

        public ActionResult SaveAttendanceApprovel(string EMP_ID, DateTime Approvel_In_Time,string ActionType,string Remark)
        {
            HrmsUserAttendanceViewModel model = new HrmsUserAttendanceViewModel();
            UserAttendanceRepo userAttendanceRepo = new UserAttendanceRepo();
            int i = userAttendanceRepo.SaveApprovelAttendance(EMP_ID, Approvel_In_Time, ActionType,Remark);

            return RedirectToAction("AttendanceIndex");
        }
    }
}



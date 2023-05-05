using HRMS.Models;
using HRMS.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Services.Description;
using System.Xml.Linq;

namespace HRMS.Controllers
{
    public class HrmsUserRegistrationController : Controller
    {
        SqlConnection conn=null;    
        public HrmsUserRegistrationController() 
        {

            string connStr = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            conn = new SqlConnection(connStr);


        }

        #region[This Get-Method is use for UserRegistration ]
        [HttpGet]
        public ActionResult UserRegistrationIndex()
        {

            MstUserRegistrationViewModel model = new MstUserRegistrationViewModel();
            return View("UserRegistrationIndex", model);
        }
        #endregion


        #region[This Post-Method is use Save Data for UserRegistration]
        [HttpPost]
        public ActionResult SaveUserRegistration(MstUserRegistrationViewModel model)
        {
            //Here we are Create object of RepoClass for Connection to DB..............
            UserRegistrationRepo userRegistrationRepo = new UserRegistrationRepo();
            
                int i = userRegistrationRepo.UserRegistrationSaveData(model);
                if (i==1)
                {
                    TempData["AlertMessage"] = "User Registration successfully...........";
                }
                else
                   TempData["AlertMessage"] = "Already Exists Please Change UserId........";
            return RedirectToAction("SignIn", "HrmsUserRegistration");

            
        }
        #endregion

        #region[This Get-Method is use for SignIn]
        [HttpGet]
        public ActionResult SignIn()
        {

            MstUserRegistrationViewModel model = new MstUserRegistrationViewModel();

            return View(model);
        }
        #endregion

        #region[This Post-Method is use for Login-user]
        [HttpPost]
        public ActionResult LogIn(MstUserRegistrationViewModel model, string UserId, string Intime)
        {
            //Here we are Create object of LogIn Repo
            UserLogInRepo userLogInRepo = new UserLogInRepo();

            #region[Here we care Create-Attendacne-Repo -method for Check-Attendance]
            UserAttendanceRepo userAttendanceRepo = new UserAttendanceRepo();
            #endregion
            //Here we can call Repo -Method...
            int i = userLogInRepo.UserLogIn(model);
            if (i == 1)
            {
                Session["UserID"] = UserId;


                TempData["Message"] = "User successfully LogIn...........";
                TempData["temp"] = model.UserId;

                //#region[ This-Method use for Show Attendance-Time]

                //var Date = userAttendanceRepo.GetUserAttendanceTime(UserId);
                //var x = Date.ToString("hh:mm tt");
                //// var y = Date.ToString("yyyy-mm-dd");
                //var y = Date.ToShortDateString();
                //if (y == "1/1/1900")
                //{
                //    TempData["InTime"] = null;
                //}
                //else
                //    TempData["InTime"] = x;

                //#endregion

                return RedirectToAction("AttendanceIndex", "HrmUserAttendance");

            }
            else
            {

                TempData["AlertMessage"] = "Please check UserId and Password.";
                return View("SignIn", model);
            }
        }
        [HttpGet]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); // it will clear the session at the end of request
            return RedirectToAction("SignIn", "HrmsUserRegistration");
        }
    }
}
        #endregion

    





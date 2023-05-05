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
    public class HrmsDepartmentController : Controller
    {
        SqlConnection conn = null;
        public HrmsDepartmentController()
        {
            string connStr = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            conn = new SqlConnection(connStr);
        }


        [HttpGet]
        public PartialViewResult AddDepartment()
        {

            HrmsDepartmentViewModel model = new HrmsDepartmentViewModel();

            return PartialView("_AddDepartment");
        }


        [HttpPost]
        public ActionResult SaveDepartment(HrmsDepartmentViewModel model)
        {
           
            HrmsDepartmentRepo hrmsDepartmentRepo = new HrmsDepartmentRepo();
            int i = hrmsDepartmentRepo.SaveDepartment(model);
            return RedirectToAction("AttendanceIndex", "HrmUserAttendance");
        }


    }


}
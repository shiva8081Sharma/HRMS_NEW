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
    public class HrmsRoleController : Controller
    {
        SqlConnection conn = null;


        public HrmsRoleController()
        {
            string connStr = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            conn = new SqlConnection(connStr);
        }

        [HttpGet]
        public PartialViewResult AddRole()
        {
            HrmsRoleViewModel model = new HrmsRoleViewModel();
            return PartialView("_AddRole");
        }


        [HttpPost]
        public ActionResult SaveRole(HrmsRoleViewModel model)
        {
       

            HrmsRoleRepo hrmsRoleRepo = new HrmsRoleRepo();
            int i = hrmsRoleRepo.SaveRole(model);
            return RedirectToAction("AttendanceIndex", "HrmUserAttendance");
        }

    }
}
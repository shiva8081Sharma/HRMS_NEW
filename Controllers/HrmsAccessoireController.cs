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
    public class HrmsAccessoireController : Controller
    {

        SqlConnection conn = null;
        public HrmsAccessoireController()
        {
            string connStr = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            conn = new SqlConnection(connStr);
        }



        [HttpGet]
        public PartialViewResult AddAccessoire()
        {

            HrmsAccessoireViewModel model = new HrmsAccessoireViewModel();

            return PartialView("_AddAccessoire");
        }

        [HttpPost]
        public ActionResult SaveAccessoire(HrmsAccessoireViewModel model)
        {

            HrmsAccessoireRepo hrmsAccessoireRepo = new HrmsAccessoireRepo();
            int i = hrmsAccessoireRepo.SaveAccessoire(model);
            return RedirectToAction("AttendanceIndex", "HrmUserAttendance");
        }

    }
}
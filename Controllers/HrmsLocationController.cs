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
    public class HrmsLocationController : Controller
    {
        SqlConnection conn = null;

        public HrmsLocationController()
        {
            string connStr = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            conn = new SqlConnection(connStr);
        }


        [HttpGet]
        public PartialViewResult AddLocation()
        {

            HrmsLocationViewModel model = new HrmsLocationViewModel();

            return PartialView("_AddLocation");
        }


        [HttpPost]
        public ActionResult SaveLocation(HrmsLocationViewModel model)
        {
            UserLocationRepo userLocationRepo = new UserLocationRepo();
            int i = userLocationRepo.SaveLocation(model);
            return RedirectToAction("HrmsUserAttendance","AttendanceIndex");
        }
    }
}
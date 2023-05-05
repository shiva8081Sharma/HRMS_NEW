using HRMS.Models;
using HRMS.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRMS.Controllers
{
    public class HrmsEmployeeDetailsController : Controller
    {

        SqlConnection conn = null;
        public HrmsEmployeeDetailsController()
        {

            string connStr = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            conn = new SqlConnection(connStr);
        }
        [HttpGet]
        public PartialViewResult AddEmployessDetails()
        {

            EmployeeDetailsRepo employeeDetailsRepo = new EmployeeDetailsRepo();
            //For DropDwon.................
             ViewBag.DropDwonlist= employeeDetailsRepo.GetEmployeeDropDwon();

            ViewBag.LocationDropdwon=employeeDetailsRepo.GetLocationDropDwon();
            ViewBag.RoleDropdwon=employeeDetailsRepo.GetRoleDropDwon();


            return PartialView("_AddEmployessDetails");
        }

        [HttpPost]
        public ActionResult SaveEmployeeDetails(HrmsEmployeeDetailsViewModel model)
        {
            EmployeeDetailsRepo employeeDetailsRepo = new EmployeeDetailsRepo();

            string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
            string Extention = Path.GetExtension(model.ImageFile.FileName);
            fileName = fileName + Extention;
            model.EMP_PHOTO_Path = "~/images/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/images/") + fileName);
            model.ImageFile.SaveAs(fileName);

            int i = employeeDetailsRepo.SaveEmployeeDetails(model);

            return RedirectToAction("AttendanceIndex", "HrmUserAttendance");

        }
    
    }
}
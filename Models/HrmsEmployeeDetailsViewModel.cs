using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRMS.Models
{
    public class HrmsEmployeeDetailsViewModel
    {

        public List<HrmsEmployeeDetailsViewModel> HrmsEmployeeDetails { get; set; }

        [Required]
        public int Id { get; set; }
        [Required]
        public string First_Name { get; set; }
       
        public string Last_Name { get; set; }
        [Required]
        public DateTime Dob { get; set; }
        public string Gender { get; set; }
        [Required]
        public string Father_Name { get; set; }

        public DateTime Date_of_joining { get; set; }
      
        [Required]
        public int Location_id { get; set; }

        [Required]
        [StringLength(12, MinimumLength = 10)]
        public string  Mobile_No { get; set;}
        [Required]
        [StringLength(12, MinimumLength = 10)]
        public string Alternate_No { get; set;}
        [Required]
        public int Contact_Manager_id { get; set; }
        [Required]
        public int Degistation_id { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public int Total_Leave { get;set; }

        public DateTime Date_of_Releave { get; set; }
        [Required]
        public string Current_Address { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email_Id { get; set;}

        public int Emp_Aadhar_Card { get; set; }
        public string EMP_PAN_CARD { get; set; }
        public string EMP_PHOTO_Path { get; set; }
        public string QUALIFICATION_DOCUMENT1 { get; set; }
        public string QUALIFICATION_DOCUMENT2 { get; set; }
        public string QUALIFICATION_DOCUMENT3 { get; set; }
        public string QUALIFICATION_DOCUMENT4 { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }


        [Required]
        public int Role_Id { get; set; }


        [Required]
        public int Emp_Id { get; set; }

        [Required]
        public string Nom_Name { get; set; }
        [Required]
        public string Nom_Share { get; set; }
        [Required]
        public string Relation_with_Emp { get; set; }
        [Required]
        public int Nom_Aadhar_No { get; set; }
        [Required]
        public string Nom_Pan_Card_No { get; set; }
        [Required]
        public DateTime Nom_Dob { get; set; }
        [Required]
        public bool Nom_Is_Minor { get; set; }
        [Required]
        public string Nom_Guardion_Name { get; set; }
        [Required]
        public string Nnom_Approver_Reark { get; set; }
        [Required]
        public int Document_id { get; set; }
        [Required]
        public string Document_Type { get; set; }
        [Required]
        public bool Is_Active { get; set; }
        [Required]

        public DateTime TimeStamp { get; set; }

       

    }
}
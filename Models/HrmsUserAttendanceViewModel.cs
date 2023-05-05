using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRMS.Models
{
    public class HrmsUserAttendanceViewModel
    {
        public List<HrmsUserAttendanceViewModel> hrmsUserAttendance { get; set; }


        public int Id { get; set; }

        public string LogIn_ID { get; set; }
        public string EMP_ID { get; set;}
    
        public DateTime IN_TIME { get; set; }

        public DateTime OUT_TIME { get; set; } 

        public DateTime APPROVEL_DATE { get;set; }

        public bool IsActive { get; set; }

        public DateTime Approvel_In_Time { get; set; }  
        public DateTime Approvel_Out_Time { get; set; }

        public string Remark { get; set; }
        [Required]
        public string Manager_Remark { get; set; }  
        
        public bool Is_Rejected { get; set; }
        public bool Is_Approved { get; set; }

        public string ActionType { get; set; }
        public string Type { get; set; }

  

        




    }
}
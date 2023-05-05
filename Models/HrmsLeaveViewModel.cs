using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS.Models
{
    public class HrmsLeaveViewModel
    {



        public List<HrmsLeaveViewModel> hrmsLeaveViewModels { get; set; }


        //This View Model View for Mst_Leave
        public int Id { get; set; }
        public string TYPE_LEAVE { get; set; }
        public bool Is_Active { get; set; }
        public DateTime Time_Stamp { get; set; }
        //This View Model View for Emp_Leave_Apply







        public string Emp_Id { get; set; }

        public int LeaveId { get; set; }

        //public string Type_leave { get; set; }

        public int APPLIED_TOTAL_LEAVE { get; set;}

        public string REASON_FOR_LEAVE { get;set; }

        public DateTime LEAVE_FROM_DATE { get; set; }
        public DateTime LEAVE_TO_DATE { get; set; }
        public DateTime TimeStamp { get; set; }

    }
}
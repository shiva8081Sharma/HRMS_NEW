using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS.Models
{
    public class HrmsDepartmentViewModel
    {

        public int Department_Id { get; set; }
        public string Department_Name { get; set; }
        public bool Is_Active { get; set; }
        public DateTime Time_Stamp { get; set; }

    }
}
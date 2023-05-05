using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS.Models
{
    public class HrmsRoleViewModel
    {
        public List<HrmsRoleViewModel> hrmsRoleViewModels { get; set; }


        public int Role_Id { get; set; }

        public string Role_type { get; set; }

        public bool Is_Active { get; set; }

        public TimeSpan Time_stamp { get; set; }
    }
}
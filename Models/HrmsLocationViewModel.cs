using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS.Models
{
    public class HrmsLocationViewModel
    {

        public List<HrmsLocationViewModel> HrmsEmployeeDetails { get; set; }


        public int LOCATION_ID { get; set; }

        public string Name { get; set; }

        public bool Is_Active { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS.Models
{
    public class HrmsAccessoireViewModel
    {


        public int Accessoire_Id { get; set; }  

        public string Accessoire_Name { get; set; }
        public string Accessoire_Type { get; set; }
        public DateTime Expence_Date { get; set; }
    }
}
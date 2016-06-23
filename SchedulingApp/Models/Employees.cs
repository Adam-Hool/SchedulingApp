using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchedulingApp.Models
{
    public class Employees
    {
        public string id { get; set; }
        public virtual string RegisteredCompanyid { get; set; }
        public string FullName { get; set; }
        public DateTime HigherDate { get; set; }
        public virtual string JobRoleid { get; set; }
        public string Availabilityid { get; set; }


    }
}
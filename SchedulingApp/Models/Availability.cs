using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchedulingApp.Models
{
    public class Availability
    {
        public string id { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }
        public virtual string RegisteredCompanyid{ get; set; }
        public ICollection<Employees> Employeesid { get; set; }


    }
}
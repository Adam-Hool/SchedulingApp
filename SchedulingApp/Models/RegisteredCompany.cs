using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchedulingApp.Models
{
    public class RegisteredCompany
    {
        public string id { get; set; }
        public string CompanyName { get; set; }
        public ICollection<Availability> Availability { get; set; }
        public ICollection<Employees> Employees { get; set; }
        public ICollection<Events> Events { get; set; }
        public ICollection<JobRole> JobRole { get; set; }
        public ICollection<Requests> Requests { get; set; }



    }
}
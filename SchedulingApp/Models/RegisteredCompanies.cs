using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchedulingApp.Models
{
    public class RegisteredCompanies
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public virtual ICollection<Events> Events { get; set; }
        public virtual ICollection<Day> Day { get; set; }
        public virtual ICollection<Schedule> Schedule { get; set; }
        public virtual ICollection<Employees> Employees { get; set; }
        public virtual ICollection<JobRole> JobRole { get; set; }
        public virtual ICollection<Availability> Availability { get; set; }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchedulingApp.Models
{
    public class Employees
    {
        public int Id { get; set; }
        public virtual ICollection<Schedule> Schedule { get; set; }
        public virtual ICollection<JobRole> JobRoles { get; set; }
        public virtual ICollection<Events> Events { get; set; }

        public int RegisteredCompaniesId { get; set; }
        public int? AvailabilityId { get; set; }
        public string FullName { get; set; }
        public DateTime HigherDate { get; set; }


    }
}
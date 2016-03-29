using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchedulingApp.Models
{
    public class Requests
    {
        public int id { get; set; }
        public string title { get; set; }
        public string date { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string url { get; set; }
        public bool allDay { get; set; }
        public virtual JobRole JobRoleId { get; set; }
        public virtual Day DayId { get; set; }
        public virtual Employees EmployeesId { get; set; }
        public string RegisteredCompany { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchedulingApp.Models
{
    public class Employees
    {
        public int EmployeesID { get; set; }
        public int RegisteredCompanyID { get; set; }
        public int ScheduleID { get; set; }
        public int JobRoleID { get; set; }
        public int ShiftID { get; set; }
        public int AvailabilityID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime HigherDate { get; set; }
        public int DesiredWeeklyHours { get; set; }


    }
}
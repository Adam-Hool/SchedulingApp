using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchedulingApp.Models
{
    public class Shift
    {
        public int ShiftID { get; set; }
        public int EmployeesID { get; set; }
        public int RegisteredCompanyID { get; set; }
        public int ScheduleID { get; set; }
        public int JobRoleID { get; set; }
        public int AvailabilityID { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Employees employee { get; set; }
        public JobRole jobRole { get; set; }
    }
}
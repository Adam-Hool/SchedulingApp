using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchedulingApp.Models
{
    public class Schedule
    {
        public int ID { get; set; }
        public int EmployeesID { get; set; }
        public int RegisteredCompanyID { get; set; }
        public int JobRoleID { get; set; }
        public int ShiftID { get; set; }
        public int AvailabilityID { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Shift shift { get; set; }
        public string ScheduleName { get; set; }
    }
}
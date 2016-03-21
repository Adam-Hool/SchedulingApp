using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchedulingApp.Models
{
    public class Availability
    {
        public int AvailabilityID { get; set; }
        public int EmployeesID { get; set; }
        public int RegisteredCompanyID { get; set; }
        public int ScheduleID { get; set; }
        public int JobRoleID { get; set; }
        public int ShiftID { get; set; }

        public Employees Employee { get; set; }
        public DateTime MondayAvailability { get; set; }
        public DateTime TuesdayAvailability { get; set; }
        public DateTime WednesdayAvailability { get; set; }
        public DateTime ThursdayAvailability { get; set; }
        public DateTime FridayAvailability { get; set; }
        public DateTime SaturdayAvailability { get; set; }
        public DateTime SundayAvailability { get; set; }

    }
}
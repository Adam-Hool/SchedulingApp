using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchedulingApp.Models
{
    public class RegisteredCompanies
    {
        public int RegisteredCompanyID { get; set; }
        public int EmployeesID { get; set; }
        public int ScheduleID { get; set; }
        public int JobRoleID { get; set; }
        public int ShiftID { get; set; }
        public int AvailabilityID { get; set; }

        public string CompanyName { get; set; }

    }
}
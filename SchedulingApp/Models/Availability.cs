using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchedulingApp.Models
{
    public class Availability
    {
        public int Id { get; set; }
        public virtual ICollection<Day> Day { get; set; }
        public int RegisteredCompaniesId { get; set; }
        public int EmployeesId { get; set; }
        public int MondayId { get; set; }
        

    }
}
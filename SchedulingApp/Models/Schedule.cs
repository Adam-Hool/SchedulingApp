using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchedulingApp.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public virtual ICollection<Day> Day { get; set; }
        public virtual Employees Employees { get; set; }
        public int RegisteredCompaniesId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ScheduleName { get; set; }

        //public Shift shift { get; set; }
        //public DateTime Monday { get; set; }
        //public DateTime Tuesday { get; set; }
        //public DateTime Wednesday { get; set; }
        //public DateTime Thursday { get; set; }
        //public DateTime Friday { get; set; }
        //public DateTime Saturday { get; set; }
        //public DateTime Sunday { get; set; }
    }
}
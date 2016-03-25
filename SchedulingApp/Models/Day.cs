using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchedulingApp.Models
{
    public class Day
    {
        public int Id { get; set; }
        public virtual ICollection<Events> Events { get; set; }
        public DateTime DayOfWeek { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public virtual Schedule Schedule { get; set; }
        public int RegisteredCompaniesId { get; set; }
    }
}
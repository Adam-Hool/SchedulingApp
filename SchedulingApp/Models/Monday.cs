using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchedulingApp.Models
{
    public class Monday
    {
        public int Id { get; set; }
        public List<Events> EventsList { get; set; }
        public bool Available { get; set; }
    }
}
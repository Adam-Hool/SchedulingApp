using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchedulingApp.Models
{
    public class JobRole
    {
        public int Id { get; set; }
        public int RegisteredCompaniesId { get; set; }
        public virtual Employees Employees { get; set; }
        public string JobTitle { get; set; }

    }
}
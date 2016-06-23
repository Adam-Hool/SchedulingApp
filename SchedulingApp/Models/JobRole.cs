using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchedulingApp.Models
{
    public class JobRole
    {
        public string id { get; set; }
        public virtual string RegisteredCompanyid { get; set; }
        public string JobTitle { get; set; }
        public ICollection<Employees> Employees { get; set; }

    }
}
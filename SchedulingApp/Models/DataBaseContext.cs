using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SchedulingApp.Models
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext() : base("DefaultConnection")
        {

        }

        public DbSet<RegisteredCompany> RegisteredCompanies { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<JobRole> JobRole { get; set; }
        public DbSet<Availability> Availability { get; set; }

        public System.Data.Entity.DbSet<SchedulingApp.Models.Events> Events { get; set; }
        public System.Data.Entity.DbSet<SchedulingApp.Models.Requests> Requests { get; set; }
    }
}
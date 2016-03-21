﻿using System;
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

        public DbSet<RegisteredCompanies> RegisteredCompanies { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<JobRole> JobRole { get; set; }
        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<Shift> Shift { get; set; }
        public DbSet<Availability> Availability { get; set; }
    }
}
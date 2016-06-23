namespace SchedulingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initalSchema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Availabilities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegisteredCompaniesId = c.Int(nullable: false),
                        EmployeesId = c.Int(),
                        MondayId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RegisteredCompanies", t => t.RegisteredCompaniesId, cascadeDelete: true)
                .Index(t => t.RegisteredCompaniesId);
            
            CreateTable(
                "dbo.Days",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DayOfWeek = c.DateTime(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        RegisteredCompaniesId = c.Int(nullable: false),
                        Schedule_Id = c.Int(),
                        Availability_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Schedules", t => t.Schedule_Id)
                .ForeignKey("dbo.Availabilities", t => t.Availability_Id)
                .ForeignKey("dbo.RegisteredCompanies", t => t.RegisteredCompaniesId, cascadeDelete: true)
                .Index(t => t.RegisteredCompaniesId)
                .Index(t => t.Schedule_Id)
                .Index(t => t.Availability_Id);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        date = c.String(),
                        start = c.String(),
                        end = c.String(),
                        url = c.String(),
                        allDay = c.Boolean(nullable: false),
                        RegisteredCompaniesId = c.Int(nullable: false),
                        Day_Id = c.Int(),
                        Employees_Id = c.Int(),
                        JobRole_Id = c.Int(),
                        Monday_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Days", t => t.Day_Id)
                .ForeignKey("dbo.Employees", t => t.Employees_Id)
                .ForeignKey("dbo.JobRoles", t => t.JobRole_Id)
                .ForeignKey("dbo.Mondays", t => t.Monday_Id)
                .ForeignKey("dbo.RegisteredCompanies", t => t.RegisteredCompaniesId, cascadeDelete: true)
                .Index(t => t.RegisteredCompaniesId)
                .Index(t => t.Day_Id)
                .Index(t => t.Employees_Id)
                .Index(t => t.JobRole_Id)
                .Index(t => t.Monday_Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegisteredCompaniesId = c.Int(nullable: false),
                        AvailabilityId = c.Int(),
                        FullName = c.String(),
                        HigherDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RegisteredCompanies", t => t.RegisteredCompaniesId, cascadeDelete: true)
                .Index(t => t.RegisteredCompaniesId);
            
            CreateTable(
                "dbo.JobRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegisteredCompaniesId = c.Int(nullable: false),
                        JobTitle = c.String(),
                        Employees_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Employees_Id)
                .ForeignKey("dbo.RegisteredCompanies", t => t.RegisteredCompaniesId, cascadeDelete: true)
                .Index(t => t.RegisteredCompaniesId)
                .Index(t => t.Employees_Id);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegisteredCompaniesId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        ScheduleName = c.String(),
                        Employees_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Employees_Id)
                .ForeignKey("dbo.RegisteredCompanies", t => t.RegisteredCompaniesId, cascadeDelete: true)
                .Index(t => t.RegisteredCompaniesId)
                .Index(t => t.Employees_Id);
            
            CreateTable(
                "dbo.Mondays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Available = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RegisteredCompanies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schedules", "RegisteredCompaniesId", "dbo.RegisteredCompanies");
            DropForeignKey("dbo.JobRoles", "RegisteredCompaniesId", "dbo.RegisteredCompanies");
            DropForeignKey("dbo.Events", "RegisteredCompaniesId", "dbo.RegisteredCompanies");
            DropForeignKey("dbo.Employees", "RegisteredCompaniesId", "dbo.RegisteredCompanies");
            DropForeignKey("dbo.Days", "RegisteredCompaniesId", "dbo.RegisteredCompanies");
            DropForeignKey("dbo.Availabilities", "RegisteredCompaniesId", "dbo.RegisteredCompanies");
            DropForeignKey("dbo.Events", "Monday_Id", "dbo.Mondays");
            DropForeignKey("dbo.Days", "Availability_Id", "dbo.Availabilities");
            DropForeignKey("dbo.Events", "JobRole_Id", "dbo.JobRoles");
            DropForeignKey("dbo.Schedules", "Employees_Id", "dbo.Employees");
            DropForeignKey("dbo.Days", "Schedule_Id", "dbo.Schedules");
            DropForeignKey("dbo.JobRoles", "Employees_Id", "dbo.Employees");
            DropForeignKey("dbo.Events", "Employees_Id", "dbo.Employees");
            DropForeignKey("dbo.Events", "Day_Id", "dbo.Days");
            DropIndex("dbo.Schedules", new[] { "Employees_Id" });
            DropIndex("dbo.Schedules", new[] { "RegisteredCompaniesId" });
            DropIndex("dbo.JobRoles", new[] { "Employees_Id" });
            DropIndex("dbo.JobRoles", new[] { "RegisteredCompaniesId" });
            DropIndex("dbo.Employees", new[] { "RegisteredCompaniesId" });
            DropIndex("dbo.Events", new[] { "Monday_Id" });
            DropIndex("dbo.Events", new[] { "JobRole_Id" });
            DropIndex("dbo.Events", new[] { "Employees_Id" });
            DropIndex("dbo.Events", new[] { "Day_Id" });
            DropIndex("dbo.Events", new[] { "RegisteredCompaniesId" });
            DropIndex("dbo.Days", new[] { "Availability_Id" });
            DropIndex("dbo.Days", new[] { "Schedule_Id" });
            DropIndex("dbo.Days", new[] { "RegisteredCompaniesId" });
            DropIndex("dbo.Availabilities", new[] { "RegisteredCompaniesId" });
            DropTable("dbo.RegisteredCompanies");
            DropTable("dbo.Mondays");
            DropTable("dbo.Schedules");
            DropTable("dbo.JobRoles");
            DropTable("dbo.Employees");
            DropTable("dbo.Events");
            DropTable("dbo.Days");
            DropTable("dbo.Availabilities");
        }
    }
}

namespace SchedulingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initalMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Availabilities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EmployeesID = c.Int(nullable: false),
                        RegisteredCompanyID = c.Int(nullable: false),
                        ScheduleID = c.Int(nullable: false),
                        JobRoleID = c.Int(nullable: false),
                        ShiftID = c.Int(nullable: false),
                        MondayAvailability = c.DateTime(nullable: false),
                        TuesdayAvailability = c.DateTime(nullable: false),
                        WednesdayAvailability = c.DateTime(nullable: false),
                        ThursdayAvailability = c.DateTime(nullable: false),
                        FridayAvailability = c.DateTime(nullable: false),
                        SaturdayAvailability = c.DateTime(nullable: false),
                        SundayAvailability = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Employees", t => t.EmployeesID, cascadeDelete: true)
                .Index(t => t.EmployeesID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RegisteredCompanyID = c.Int(nullable: false),
                        ScheduleID = c.Int(nullable: false),
                        JobRoleID = c.Int(nullable: false),
                        ShiftID = c.Int(nullable: false),
                        AvailabilityID = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        HigherDate = c.DateTime(nullable: false),
                        DesiredWeeklyHours = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.JobRoles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CompanyID = c.Int(nullable: false),
                        ShiftID = c.Int(nullable: false),
                        ScheduleID = c.Int(nullable: false),
                        RegisteredCompanyID = c.Int(nullable: false),
                        AvailabilityID = c.Int(nullable: false),
                        JobTitle = c.String(),
                        Employees_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Employees", t => t.Employees_ID)
                .Index(t => t.Employees_ID);
            
            CreateTable(
                "dbo.RegisteredCompanies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EmployeesID = c.Int(nullable: false),
                        ScheduleID = c.Int(nullable: false),
                        JobRoleID = c.Int(nullable: false),
                        ShiftID = c.Int(nullable: false),
                        AvailabilityID = c.Int(nullable: false),
                        CompanyName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EmployeesID = c.Int(nullable: false),
                        RegisteredCompanyID = c.Int(nullable: false),
                        JobRoleID = c.Int(nullable: false),
                        ShiftID = c.Int(nullable: false),
                        AvailabilityID = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        ScheduleName = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Shifts", t => t.ShiftID, cascadeDelete: true)
                .Index(t => t.ShiftID);
            
            CreateTable(
                "dbo.Shifts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EmployeesID = c.Int(nullable: false),
                        RegisteredCompanyID = c.Int(nullable: false),
                        ScheduleID = c.Int(nullable: false),
                        JobRoleID = c.Int(nullable: false),
                        AvailabilityID = c.Int(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Employees", t => t.EmployeesID, cascadeDelete: true)
                .ForeignKey("dbo.JobRoles", t => t.JobRoleID, cascadeDelete: true)
                .Index(t => t.EmployeesID)
                .Index(t => t.JobRoleID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schedules", "ShiftID", "dbo.Shifts");
            DropForeignKey("dbo.Shifts", "JobRoleID", "dbo.JobRoles");
            DropForeignKey("dbo.Shifts", "EmployeesID", "dbo.Employees");
            DropForeignKey("dbo.Availabilities", "EmployeesID", "dbo.Employees");
            DropForeignKey("dbo.JobRoles", "Employees_ID", "dbo.Employees");
            DropIndex("dbo.Shifts", new[] { "JobRoleID" });
            DropIndex("dbo.Shifts", new[] { "EmployeesID" });
            DropIndex("dbo.Schedules", new[] { "ShiftID" });
            DropIndex("dbo.JobRoles", new[] { "Employees_ID" });
            DropIndex("dbo.Availabilities", new[] { "EmployeesID" });
            DropTable("dbo.Shifts");
            DropTable("dbo.Schedules");
            DropTable("dbo.RegisteredCompanies");
            DropTable("dbo.JobRoles");
            DropTable("dbo.Employees");
            DropTable("dbo.Availabilities");
        }
    }
}

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
                        id = c.String(nullable: false, maxLength: 128),
                        Monday = c.Boolean(nullable: false),
                        Tuesday = c.Boolean(nullable: false),
                        Wednesday = c.Boolean(nullable: false),
                        Thursday = c.Boolean(nullable: false),
                        Friday = c.Boolean(nullable: false),
                        Saturday = c.Boolean(nullable: false),
                        Sunday = c.Boolean(nullable: false),
                        RegisteredCompanyid = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.RegisteredCompanies", t => t.RegisteredCompanyid)
                .Index(t => t.RegisteredCompanyid);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        RegisteredCompanyid = c.String(maxLength: 128),
                        FullName = c.String(),
                        HigherDate = c.DateTime(nullable: false),
                        JobRoleid = c.String(maxLength: 128),
                        Availabilityid = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Availabilities", t => t.Availabilityid)
                .ForeignKey("dbo.JobRoles", t => t.JobRoleid)
                .ForeignKey("dbo.RegisteredCompanies", t => t.RegisteredCompanyid)
                .Index(t => t.RegisteredCompanyid)
                .Index(t => t.JobRoleid)
                .Index(t => t.Availabilityid);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        title = c.String(),
                        date = c.String(),
                        start = c.String(),
                        end = c.String(),
                        url = c.String(),
                        allDay = c.Boolean(nullable: false),
                        RegisteredCompanyid = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.RegisteredCompanies", t => t.RegisteredCompanyid)
                .Index(t => t.RegisteredCompanyid);
            
            CreateTable(
                "dbo.JobRoles",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        RegisteredCompanyid = c.String(maxLength: 128),
                        JobTitle = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.RegisteredCompanies", t => t.RegisteredCompanyid)
                .Index(t => t.RegisteredCompanyid);
            
            CreateTable(
                "dbo.RegisteredCompanies",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        CompanyName = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        title = c.String(),
                        date = c.String(),
                        start = c.String(),
                        end = c.String(),
                        url = c.String(),
                        allDay = c.Boolean(nullable: false),
                        RegisteredCompanyid = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.RegisteredCompanies", t => t.RegisteredCompanyid)
                .Index(t => t.RegisteredCompanyid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requests", "RegisteredCompanyid", "dbo.RegisteredCompanies");
            DropForeignKey("dbo.JobRoles", "RegisteredCompanyid", "dbo.RegisteredCompanies");
            DropForeignKey("dbo.Events", "RegisteredCompanyid", "dbo.RegisteredCompanies");
            DropForeignKey("dbo.Employees", "RegisteredCompanyid", "dbo.RegisteredCompanies");
            DropForeignKey("dbo.Availabilities", "RegisteredCompanyid", "dbo.RegisteredCompanies");
            DropForeignKey("dbo.Employees", "JobRoleid", "dbo.JobRoles");
            DropForeignKey("dbo.Employees", "Availabilityid", "dbo.Availabilities");
            DropIndex("dbo.Requests", new[] { "RegisteredCompanyid" });
            DropIndex("dbo.JobRoles", new[] { "RegisteredCompanyid" });
            DropIndex("dbo.Events", new[] { "RegisteredCompanyid" });
            DropIndex("dbo.Employees", new[] { "Availabilityid" });
            DropIndex("dbo.Employees", new[] { "JobRoleid" });
            DropIndex("dbo.Employees", new[] { "RegisteredCompanyid" });
            DropIndex("dbo.Availabilities", new[] { "RegisteredCompanyid" });
            DropTable("dbo.Requests");
            DropTable("dbo.RegisteredCompanies");
            DropTable("dbo.JobRoles");
            DropTable("dbo.Events");
            DropTable("dbo.Employees");
            DropTable("dbo.Availabilities");
        }
    }
}

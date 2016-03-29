namespace SchedulingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedRequests : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        date = c.String(),
                        start = c.String(),
                        end = c.String(),
                        url = c.String(),
                        allDay = c.Boolean(nullable: false),
                        RegisteredCompany = c.String(),
                        DayId_Id = c.Int(),
                        EmployeesId_Id = c.Int(),
                        JobRoleId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Days", t => t.DayId_Id)
                .ForeignKey("dbo.Employees", t => t.EmployeesId_Id)
                .ForeignKey("dbo.JobRoles", t => t.JobRoleId_Id)
                .Index(t => t.DayId_Id)
                .Index(t => t.EmployeesId_Id)
                .Index(t => t.JobRoleId_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requests", "JobRoleId_Id", "dbo.JobRoles");
            DropForeignKey("dbo.Requests", "EmployeesId_Id", "dbo.Employees");
            DropForeignKey("dbo.Requests", "DayId_Id", "dbo.Days");
            DropIndex("dbo.Requests", new[] { "JobRoleId_Id" });
            DropIndex("dbo.Requests", new[] { "EmployeesId_Id" });
            DropIndex("dbo.Requests", new[] { "DayId_Id" });
            DropTable("dbo.Requests");
        }
    }
}

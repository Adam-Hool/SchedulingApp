namespace SchedulingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedEmployeesId : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Events", name: "Day_Id", newName: "DayId_Id");
            RenameColumn(table: "dbo.Events", name: "Employees_Id", newName: "EmployeesId_Id");
            RenameColumn(table: "dbo.Events", name: "JobRole_Id", newName: "JobRoleId_Id");
            RenameIndex(table: "dbo.Events", name: "IX_Day_Id", newName: "IX_DayId_Id");
            RenameIndex(table: "dbo.Events", name: "IX_Employees_Id", newName: "IX_EmployeesId_Id");
            RenameIndex(table: "dbo.Events", name: "IX_JobRole_Id", newName: "IX_JobRoleId_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Events", name: "IX_JobRoleId_Id", newName: "IX_JobRole_Id");
            RenameIndex(table: "dbo.Events", name: "IX_EmployeesId_Id", newName: "IX_Employees_Id");
            RenameIndex(table: "dbo.Events", name: "IX_DayId_Id", newName: "IX_Day_Id");
            RenameColumn(table: "dbo.Events", name: "JobRoleId_Id", newName: "JobRole_Id");
            RenameColumn(table: "dbo.Events", name: "EmployeesId_Id", newName: "Employees_Id");
            RenameColumn(table: "dbo.Events", name: "DayId_Id", newName: "Day_Id");
        }
    }
}

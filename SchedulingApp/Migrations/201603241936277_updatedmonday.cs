namespace SchedulingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedmonday : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Availabilities", "EmployeesId", c => c.Int(nullable: false));
            AlterColumn("dbo.Availabilities", "MondayId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Availabilities", "MondayId", c => c.Int());
            AlterColumn("dbo.Availabilities", "EmployeesId", c => c.Int());
        }
    }
}

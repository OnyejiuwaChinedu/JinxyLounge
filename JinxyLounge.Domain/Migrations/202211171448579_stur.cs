namespace JinxyLounge.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stur : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmployeeTypes", "TypeName", c => c.String());
            DropColumn("dbo.EmployeeTypes", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EmployeeTypes", "Name", c => c.String());
            DropColumn("dbo.EmployeeTypes", "TypeName");
        }
    }
}

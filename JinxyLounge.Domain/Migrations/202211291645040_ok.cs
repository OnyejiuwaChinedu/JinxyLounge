namespace JinxyLounge.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ok : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Payments", "CardNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Payments", "CardNumber", c => c.String());
        }
    }
}

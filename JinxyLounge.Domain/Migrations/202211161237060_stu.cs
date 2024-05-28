namespace JinxyLounge.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stu : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Mfg_Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Products", "Exp_Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Exp_Date", c => c.String());
            AlterColumn("dbo.Products", "Mfg_Date", c => c.String());
        }
    }
}

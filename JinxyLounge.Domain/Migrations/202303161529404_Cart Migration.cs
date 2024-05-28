namespace JinxyLounge.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CartMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ProductID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "ProductID");
        }
    }
}

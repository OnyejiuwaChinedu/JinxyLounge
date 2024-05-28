namespace JinxyLounge.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pic : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        URL = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProductImages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        ImageID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Images", t => t.ImageID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.ImageID);
            
            AddColumn("dbo.Products", "ProductURL", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductImages", "ProductID", "dbo.Products");
            DropForeignKey("dbo.ProductImages", "ImageID", "dbo.Images");
            DropIndex("dbo.ProductImages", new[] { "ImageID" });
            DropIndex("dbo.ProductImages", new[] { "ProductID" });
            DropColumn("dbo.Products", "ProductURL");
            DropTable("dbo.ProductImages");
            DropTable("dbo.Images");
        }
    }
}

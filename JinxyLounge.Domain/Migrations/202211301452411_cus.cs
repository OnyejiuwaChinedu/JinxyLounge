namespace JinxyLounge.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        OrderId_Id = c.Int(),
                        ProductId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId_Id)
                .ForeignKey("dbo.Products", t => t.ProductId_Id)
                .Index(t => t.OrderId_Id)
                .Index(t => t.ProductId_Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Order_date = c.String(nullable: false),
                        Quantity = c.String(),
                        Pick_up_date = c.DateTime(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Address = c.String(),
                        CustomerId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId_Id)
                .Index(t => t.CustomerId_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoices", "ProductId_Id", "dbo.Products");
            DropForeignKey("dbo.Invoices", "OrderId_Id", "dbo.Orders");
            DropForeignKey("dbo.Orders", "CustomerId_Id", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "CustomerId_Id" });
            DropIndex("dbo.Invoices", new[] { "ProductId_Id" });
            DropIndex("dbo.Invoices", new[] { "OrderId_Id" });
            DropTable("dbo.Orders");
            DropTable("dbo.Invoices");
        }
    }
}

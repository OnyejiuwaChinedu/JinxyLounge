namespace JinxyLounge.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Payment_type = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Currency = c.String(),
                        Phone = c.String(),
                        Description = c.String(),
                        CardNumber = c.String(),
                        CustomerId_Id = c.Int(),
                        ProductId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId_Id)
                .ForeignKey("dbo.Products", t => t.ProductId_Id)
                .Index(t => t.CustomerId_Id)
                .Index(t => t.ProductId_Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstName = c.String(),
                        Phone = c.Int(nullable: false),
                        Address = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstName = c.String(),
                        OtherName = c.String(),
                        Phone = c.Int(nullable: false),
                        Address = c.String(),
                        Sex = c.String(),
                        Date_Of_Birth = c.DateTime(nullable: false),
                        State = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "ProductId_Id", "dbo.Products");
            DropForeignKey("dbo.Payments", "CustomerId_Id", "dbo.Customers");
            DropIndex("dbo.Payments", new[] { "ProductId_Id" });
            DropIndex("dbo.Payments", new[] { "CustomerId_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Customers");
            DropTable("dbo.Payments");
        }
    }
}

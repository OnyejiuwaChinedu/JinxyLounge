namespace JinxyLounge.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JinxyLoungeDomain : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        Date_Of_Birth = c.DateTime(nullable: false),
                        Age = c.Int(nullable: false),
                        Start_Date = c.DateTime(nullable: false),
                        EmployeeTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.EmployeeTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EmployeeTypes");
            DropTable("dbo.Employees");
        }
    }
}

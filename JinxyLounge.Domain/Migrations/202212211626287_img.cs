﻿namespace JinxyLounge.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class img : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Images", newName: "ProImages");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.ProImages", newName: "Images");
        }
    }
}

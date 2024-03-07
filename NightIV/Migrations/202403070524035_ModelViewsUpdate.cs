﻿namespace NightIV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelViewsUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false));
        }
    }
}

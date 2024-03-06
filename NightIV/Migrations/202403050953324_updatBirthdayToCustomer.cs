namespace NightIV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatBirthdayToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Birthday", c => c.DateTime(nullable: false));
            DropColumn("dbo.Customers", "Email");
            DropColumn("dbo.Customers", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Password", c => c.String());
            AddColumn("dbo.Customers", "Email", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Customers", "Birthday");
        }
    }
}

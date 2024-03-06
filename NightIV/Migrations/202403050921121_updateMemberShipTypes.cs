namespace NightIV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateMemberShipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MemberShipTypes SET Name = 'Free' WHERE Id = 1");
            Sql("UPDATE MemberShipTypes SET Name = 'Pay As You Go' WHERE Id = 2");
            Sql("UPDATE MemberShipTypes SET Name = 'Monthly' WHERE Id = 3");
            Sql("UPDATE MemberShipTypes SET Name = 'Yearly' WHERE Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}

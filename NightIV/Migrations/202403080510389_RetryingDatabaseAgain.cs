namespace NightIV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RetryingDatabaseAgain : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Birthday = c.DateTime(),
                        IsSubscribed = c.Boolean(nullable: false),
                        MemberShipTypeId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MemberShipTypes", t => t.MemberShipTypeId, cascadeDelete: true)
                .Index(t => t.MemberShipTypeId);
            
            CreateTable(
                "dbo.MemberShipTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        SignUpFee = c.Short(nullable: false),
                        DurationInMonths = c.Byte(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        ReleaseDate = c.DateTime(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        Stock = c.Int(nullable: false),
                        GenresId = c.Byte(nullable: false),
                        Genres_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.Genres_Id)
                .Index(t => t.Genres_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "Genres_Id", "dbo.Genres");
            DropForeignKey("dbo.Customers", "MemberShipTypeId", "dbo.MemberShipTypes");
            DropIndex("dbo.Movies", new[] { "Genres_Id" });
            DropIndex("dbo.Customers", new[] { "MemberShipTypeId" });
            DropTable("dbo.Movies");
            DropTable("dbo.Genres");
            DropTable("dbo.MemberShipTypes");
            DropTable("dbo.Customers");
        }
    }
}

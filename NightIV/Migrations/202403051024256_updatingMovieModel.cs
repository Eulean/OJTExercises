namespace NightIV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatingMovieModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Generes", c => c.String());
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "Stock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Stock");
            DropColumn("dbo.Movies", "DateAdded");
            DropColumn("dbo.Movies", "ReleaseDate");
            DropColumn("dbo.Movies", "Generes");
        }
    }
}

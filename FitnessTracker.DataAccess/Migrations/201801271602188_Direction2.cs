namespace FitnessTracker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Direction2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Direction", "DirectionName", c => c.String());
            AddColumn("dbo.Direction", "Street", c => c.String());
            AddColumn("dbo.Direction", "StreetId", c => c.Int(nullable: false));
            AddColumn("dbo.Direction", "Date", c => c.String());
            DropColumn("dbo.Direction", "OriginLat");
            DropColumn("dbo.Direction", "OriginLng");
            DropColumn("dbo.Direction", "DestinationLat");
            DropColumn("dbo.Direction", "DestinationLng");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Direction", "DestinationLng", c => c.Double(nullable: false));
            AddColumn("dbo.Direction", "DestinationLat", c => c.Double(nullable: false));
            AddColumn("dbo.Direction", "OriginLng", c => c.Double(nullable: false));
            AddColumn("dbo.Direction", "OriginLat", c => c.Double(nullable: false));
            DropColumn("dbo.Direction", "Date");
            DropColumn("dbo.Direction", "StreetId");
            DropColumn("dbo.Direction", "Street");
            DropColumn("dbo.Direction", "DirectionName");
        }
    }
}

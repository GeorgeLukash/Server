namespace FitnessTracker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Direction : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Direction",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Distance = c.Int(nullable: false),
                        Duration = c.Double(nullable: false),
                        OriginLat = c.Double(nullable: false),
                        OriginLng = c.Double(nullable: false),
                        Speed = c.Double(nullable: false),
                        DestinationLat = c.Double(nullable: false),
                        DestinationLng = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Direction");
        }
    }
}

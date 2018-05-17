namespace FitnessTracker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Direction1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.PlanEntityUserEntities", newName: "UserEntityPlanEntities");
            DropPrimaryKey("dbo.UserEntityPlanEntities");
            AddColumn("dbo.Direction", "Owner_Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.UserEntityPlanEntities", new[] { "UserEntity_Id", "PlanEntity_Id" });
            CreateIndex("dbo.Direction", "Owner_Id");
            AddForeignKey("dbo.Direction", "Owner_Id", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Direction", "Owner_Id", "dbo.Users");
            DropIndex("dbo.Direction", new[] { "Owner_Id" });
            DropPrimaryKey("dbo.UserEntityPlanEntities");
            DropColumn("dbo.Direction", "Owner_Id");
            AddPrimaryKey("dbo.UserEntityPlanEntities", new[] { "PlanEntity_Id", "UserEntity_Id" });
            RenameTable(name: "dbo.UserEntityPlanEntities", newName: "PlanEntityUserEntities");
        }
    }
}

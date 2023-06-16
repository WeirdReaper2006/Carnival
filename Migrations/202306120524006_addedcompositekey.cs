namespace Carnival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcompositekey : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.FoodStallRelationships");
            AddPrimaryKey("dbo.FoodStallRelationships", new[] { "FoodID", "StallID" });
            DropColumn("dbo.FoodStallRelationships", "RefID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FoodStallRelationships", "RefID", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.FoodStallRelationships");
            AddPrimaryKey("dbo.FoodStallRelationships", "RefID");
        }
    }
}

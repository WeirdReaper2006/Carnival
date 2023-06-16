namespace Carnival.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                {
                    CustomerID = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Address = c.String(),
                    ContactNo = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.CustomerID);

            CreateTable(
                "dbo.Food_Product",
                c => new
                {
                    FoodID = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Description = c.String(),
                    Price = c.Double(nullable: false),
                })
                .PrimaryKey(t => t.FoodID);

            CreateTable(
                "dbo.FoodStallRelationships",
                c => new
                {
                    RefID = c.Int(nullable: false, identity: true),
                    FoodID = c.Int(nullable: false),
                    StallID = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.RefID)
                .ForeignKey("dbo.Food_Product", t => t.FoodID, cascadeDelete: true)
                .ForeignKey("dbo.Stalls", t => t.StallID, cascadeDelete: true)
                .Index(t => t.FoodID)
                .Index(t => t.StallID);

            CreateTable(
                "dbo.Stalls",
                c => new
                {
                    StallID = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Address = c.String(),
                    Specialty = c.String(),
                })
                .PrimaryKey(t => t.StallID);

            CreateTable(
                "dbo.Orders",
                c => new
                {
                    OrderID = c.Int(nullable: false, identity: true),
                    CustomerID = c.Int(nullable: false),
                    FoodID = c.Int(nullable: false),
                    Quantity = c.Int(nullable: false),
                    StallID = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Food_Product", t => t.FoodID, cascadeDelete: true)
                .ForeignKey("dbo.Stalls", t => t.StallID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.FoodID)
                .Index(t => t.StallID);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Orders", "StallID", "dbo.Stalls");
            DropForeignKey("dbo.Orders", "FoodID", "dbo.Food_Product");
            DropForeignKey("dbo.Orders", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.FoodStallRelationships", "StallID", "dbo.Stalls");
            DropForeignKey("dbo.FoodStallRelationships", "FoodID", "dbo.Food_Product");
            DropIndex("dbo.Orders", new[] { "StallID" });
            DropIndex("dbo.Orders", new[] { "FoodID" });
            DropIndex("dbo.Orders", new[] { "CustomerID" });
            DropIndex("dbo.FoodStallRelationships", new[] { "StallID" });
            DropIndex("dbo.FoodStallRelationships", new[] { "FoodID" });
            DropTable("dbo.Orders");
            DropTable("dbo.Stalls");
            DropTable("dbo.FoodStallRelationships");
            DropTable("dbo.Food_Product");
            DropTable("dbo.Customers");
        }
    }
}

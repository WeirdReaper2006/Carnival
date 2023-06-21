namespace Carnival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedstoredprocedure : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GetOrderLinqs",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        Customer_Name = c.String(),
                        ContactNo = c.String(),
                        Food = c.String(),
                        Stall_Name = c.String(),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GetOrderLinqs");
        }
    }
}

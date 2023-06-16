namespace Carnival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedsettingofcustomer : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "ContactNo", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "ContactNo", c => c.Int(nullable: false));
        }
    }
}

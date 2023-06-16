namespace Carnival.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class donotalllownull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "ContactNo", c => c.String(nullable: false));
            AlterColumn("dbo.Stalls", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Stalls", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Stalls", "Specialty", c => c.String(nullable: false));
        }

        public override void Down()
        {
            AlterColumn("dbo.Stalls", "Specialty", c => c.String());
            AlterColumn("dbo.Stalls", "Address", c => c.String());
            AlterColumn("dbo.Stalls", "Name", c => c.String());
            AlterColumn("dbo.Customers", "ContactNo", c => c.String());
            AlterColumn("dbo.Customers", "Address", c => c.String());
            AlterColumn("dbo.Customers", "Name", c => c.String());
        }
    }
}

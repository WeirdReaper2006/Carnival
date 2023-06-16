namespace Carnival.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class nullvalueschanged : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Food_Product", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Food_Product", "Description", c => c.String(nullable: false));
        }

        public override void Down()
        {
            AlterColumn("dbo.Food_Product", "Description", c => c.String());
            AlterColumn("dbo.Food_Product", "Name", c => c.String());
        }
    }
}

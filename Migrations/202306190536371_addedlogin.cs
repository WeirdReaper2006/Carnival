namespace Carnival.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class addedlogin : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Logins",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Username = c.Int(nullable: false),
                    Password = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.ID);

        }

        public override void Down()
        {
            DropTable("dbo.Logins");
        }
    }
}

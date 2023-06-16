namespace Carnival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedsignupform : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Logins", "Username", c => c.String(nullable: false));
            AlterColumn("dbo.Logins", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Logins", "Password", c => c.Int(nullable: false));
            AlterColumn("dbo.Logins", "Username", c => c.Int(nullable: false));
        }
    }
}

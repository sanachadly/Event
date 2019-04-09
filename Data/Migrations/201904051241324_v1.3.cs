namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v13 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "EventFK", c => c.Int(nullable: false));
            AddColumn("dbo.Tasks", "UserFK", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tasks", "UserFK");
            DropColumn("dbo.Tasks", "EventFK");
        }
    }
}

namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tasks", "UserFK", "dbo.Users");
            DropIndex("dbo.Tasks", new[] { "UserFK" });
            AddColumn("dbo.Tasks", "UserID_UserID", c => c.Int());
            CreateIndex("dbo.Tasks", "UserID_UserID");
            AddForeignKey("dbo.Tasks", "UserID_UserID", "dbo.Users", "UserID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "UserID_UserID", "dbo.Users");
            DropIndex("dbo.Tasks", new[] { "UserID_UserID" });
            DropColumn("dbo.Tasks", "UserID_UserID");
            CreateIndex("dbo.Tasks", "UserFK");
            AddForeignKey("dbo.Tasks", "UserFK", "dbo.Users", "UserID", cascadeDelete: true);
        }
    }
}

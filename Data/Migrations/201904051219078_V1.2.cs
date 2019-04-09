namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V12 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Tasks", name: "Event_EventID", newName: "EventID_EventID");
            RenameIndex(table: "dbo.Tasks", name: "IX_Event_EventID", newName: "IX_EventID_EventID");
            AddColumn("dbo.Tasks", "UserID_UserID", c => c.Int());
            CreateIndex("dbo.Tasks", "UserID_UserID");
            AddForeignKey("dbo.Tasks", "UserID_UserID", "dbo.Users", "UserID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "UserID_UserID", "dbo.Users");
            DropIndex("dbo.Tasks", new[] { "UserID_UserID" });
            DropColumn("dbo.Tasks", "UserID_UserID");
            RenameIndex(table: "dbo.Tasks", name: "IX_EventID_EventID", newName: "IX_Event_EventID");
            RenameColumn(table: "dbo.Tasks", name: "EventID_EventID", newName: "Event_EventID");
        }
    }
}

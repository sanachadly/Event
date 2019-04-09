namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tasks", "EventID", "dbo.Event");
            DropIndex("dbo.Tasks", new[] { "EventID" });
            RenameColumn(table: "dbo.Tasks", name: "EventID", newName: "Event_EventID");
            AlterColumn("dbo.Tasks", "Event_EventID", c => c.Int());
            CreateIndex("dbo.Tasks", "Event_EventID");
            AddForeignKey("dbo.Tasks", "Event_EventID", "dbo.Event", "EventID");
            DropColumn("dbo.Tasks", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tasks", "UserID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Tasks", "Event_EventID", "dbo.Event");
            DropIndex("dbo.Tasks", new[] { "Event_EventID" });
            AlterColumn("dbo.Tasks", "Event_EventID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Tasks", name: "Event_EventID", newName: "EventID");
            CreateIndex("dbo.Tasks", "EventID");
            AddForeignKey("dbo.Tasks", "EventID", "dbo.Event", "EventID", cascadeDelete: true);
        }
    }
}

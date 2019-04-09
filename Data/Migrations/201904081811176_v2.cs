namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tasks", "UserID_UserID", "dbo.Users");
            DropIndex("dbo.Tasks", new[] { "UserID_UserID" });
            RenameColumn(table: "dbo.Tasks", name: "UserID_UserID", newName: "UserID");
            AlterColumn("dbo.Tasks", "UserID", c => c.Int(nullable: false));
            CreateIndex("dbo.Tasks", "UserID");
            AddForeignKey("dbo.Tasks", "UserID", "dbo.Users", "UserID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "UserID", "dbo.Users");
            DropIndex("dbo.Tasks", new[] { "UserID" });
            AlterColumn("dbo.Tasks", "UserID", c => c.Int());
            RenameColumn(table: "dbo.Tasks", name: "UserID", newName: "UserID_UserID");
            CreateIndex("dbo.Tasks", "UserID_UserID");
            AddForeignKey("dbo.Tasks", "UserID_UserID", "dbo.Users", "UserID");
        }
    }
}

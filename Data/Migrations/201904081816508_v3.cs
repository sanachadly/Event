namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tasks", "UserFK");
            RenameColumn(table: "dbo.Tasks", name: "UserID", newName: "UserFK");
            RenameIndex(table: "dbo.Tasks", name: "IX_UserID", newName: "IX_UserFK");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Tasks", name: "IX_UserFK", newName: "IX_UserID");
            RenameColumn(table: "dbo.Tasks", name: "UserFK", newName: "UserID");
            AddColumn("dbo.Tasks", "UserFK", c => c.Int(nullable: false));
        }
    }
}

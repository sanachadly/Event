namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Event",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        Titre = c.String(),
                        Categorie = c.Int(nullable: false),
                        DateDebut = c.DateTime(nullable: false),
                        DateFin = c.DateTime(nullable: false),
                        Image = c.String(),
                        Lieu = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.EventID);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        TaskID = c.Int(nullable: false, identity: true),
                        Objet = c.String(),
                        DateLimite = c.DateTime(nullable: false),
                        EventID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TaskID)
                .ForeignKey("dbo.Event", t => t.EventID, cascadeDelete: true)
                .Index(t => t.EventID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Prenom = c.String(),
                        DateNaissance = c.DateTime(nullable: false),
                        Mail = c.String(),
                        Role = c.Int(nullable: false),
                        Login = c.String(),
                        MotDePasse = c.String(),
                        Ticket_TicketID = c.Int(),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Tickets", t => t.Ticket_TicketID)
                .Index(t => t.Ticket_TicketID);
            
            CreateTable(
                "dbo.Sondages",
                c => new
                    {
                        SondageID = c.Int(nullable: false, identity: true),
                        EventID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        Titre = c.String(),
                        Contenu = c.String(),
                        DateExpiration = c.DateTime(nullable: false),
                        Resultat = c.String(),
                    })
                .PrimaryKey(t => t.SondageID);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        TicketID = c.Int(nullable: false, identity: true),
                        DateValidite = c.DateTime(nullable: false),
                        UserID = c.Int(nullable: false),
                        EventID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TicketID);
            
            CreateTable(
                "dbo.UserEvents",
                c => new
                    {
                        User_UserID = c.Int(nullable: false),
                        Event_EventID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_UserID, t.Event_EventID })
                .ForeignKey("dbo.Users", t => t.User_UserID, cascadeDelete: true)
                .ForeignKey("dbo.Event", t => t.Event_EventID, cascadeDelete: true)
                .Index(t => t.User_UserID)
                .Index(t => t.Event_EventID);
            
            CreateTable(
                "dbo.SondageUsers",
                c => new
                    {
                        Sondage_SondageID = c.Int(nullable: false),
                        User_UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Sondage_SondageID, t.User_UserID })
                .ForeignKey("dbo.Sondages", t => t.Sondage_SondageID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_UserID, cascadeDelete: true)
                .Index(t => t.Sondage_SondageID)
                .Index(t => t.User_UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Ticket_TicketID", "dbo.Tickets");
            DropForeignKey("dbo.SondageUsers", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.SondageUsers", "Sondage_SondageID", "dbo.Sondages");
            DropForeignKey("dbo.UserEvents", "Event_EventID", "dbo.Event");
            DropForeignKey("dbo.UserEvents", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.Tasks", "EventID", "dbo.Event");
            DropIndex("dbo.SondageUsers", new[] { "User_UserID" });
            DropIndex("dbo.SondageUsers", new[] { "Sondage_SondageID" });
            DropIndex("dbo.UserEvents", new[] { "Event_EventID" });
            DropIndex("dbo.UserEvents", new[] { "User_UserID" });
            DropIndex("dbo.Users", new[] { "Ticket_TicketID" });
            DropIndex("dbo.Tasks", new[] { "EventID" });
            DropTable("dbo.SondageUsers");
            DropTable("dbo.UserEvents");
            DropTable("dbo.Tickets");
            DropTable("dbo.Sondages");
            DropTable("dbo.Users");
            DropTable("dbo.Tasks");
            DropTable("dbo.Event");
        }
    }
}

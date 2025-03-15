namespace AppGestionRendezVous.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agenda",
                c => new
                    {
                        IdAgenda = c.Int(nullable: false, identity: true),
                        DatePlanifier = c.DateTime(nullable: false, precision: 0),
                        Titre = c.String(unicode: false),
                        HeureDebut = c.String(unicode: false),
                        HeureFin = c.String(unicode: false),
                        Creneau = c.Int(nullable: false),
                        Lieu = c.String(unicode: false),
                        statut = c.String(unicode: false),
                        IdMedcin = c.Int(),
                    })
                .PrimaryKey(t => t.IdAgenda)
                .ForeignKey("dbo.Personnes", t => t.IdMedcin)
                .Index(t => t.IdMedcin);
            
            CreateTable(
                "dbo.Creneaux",
                c => new
                    {
                        IdCreneau = c.Int(nullable: false, identity: true),
                        IdAgenda = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false, precision: 0),
                        HeureDebut = c.String(unicode: false),
                        HeureFin = c.String(unicode: false),
                        Disponible = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdCreneau)
                .ForeignKey("dbo.Agenda", t => t.IdAgenda, cascadeDelete: true)
                .Index(t => t.IdAgenda);
            
            CreateTable(
                "dbo.Personnes",
                c => new
                    {
                        IdU = c.Int(nullable: false, identity: true),
                        NomPrenom = c.String(nullable: false, maxLength: 200, storeType: "nvarchar"),
                        Email = c.String(nullable: false, maxLength: 200, storeType: "nvarchar"),
                        Adresse = c.String(nullable: false, maxLength: 80, storeType: "nvarchar"),
                        Tel = c.String(nullable: false, maxLength: 20, storeType: "nvarchar"),
                        Identifiant = c.String(maxLength: 20, storeType: "nvarchar"),
                        MotDePasse = c.String(maxLength: 250, storeType: "nvarchar"),
                        statuts = c.Boolean(),
                        IdSpecialite = c.Int(),
                        NumeroOrdre = c.String(maxLength: 10, storeType: "nvarchar"),
                        GroupeSangin = c.String(maxLength: 3, storeType: "nvarchar"),
                        Poids = c.Single(),
                        Taille = c.Single(),
                        IdGroupeSanguin = c.Int(),
                        TeleohoneFixe = c.String(maxLength: 15, storeType: "nvarchar"),
                        Discriminator = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.IdU)
                .ForeignKey("dbo.Specialites", t => t.IdSpecialite)
                .ForeignKey("dbo.GroupeSanguins", t => t.IdGroupeSanguin)
                .Index(t => t.IdSpecialite)
                .Index(t => t.IdGroupeSanguin);
            
            CreateTable(
                "dbo.Specialites",
                c => new
                    {
                        IdSpecialite = c.Int(nullable: false, identity: true),
                        CodeSpecialite = c.String(nullable: false, maxLength: 10, storeType: "nvarchar"),
                        NomSpecialite = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.IdSpecialite);
            
            CreateTable(
                "dbo.RendezVous",
                c => new
                    {
                        IdRendezVous = c.Int(nullable: false, identity: true),
                        Statut = c.String(unicode: false),
                        DateRv = c.DateTime(nullable: false, precision: 0),
                        Creneau = c.String(unicode: false),
                        ReferencePayment = c.String(unicode: false),
                        NumRecu = c.String(unicode: false),
                        IdSoin = c.Int(),
                        IdMoyenPay = c.Int(nullable: false),
                        IdPatient = c.Int(nullable: false),
                        IdPay = c.Int(),
                        IdMedcin = c.Int(),
                        Agenda_IdAgenda = c.Int(),
                    })
                .PrimaryKey(t => t.IdRendezVous)
                .ForeignKey("dbo.Personnes", t => t.IdMedcin)
                .ForeignKey("dbo.MoyenPayments", t => t.IdMoyenPay, cascadeDelete: true)
                .ForeignKey("dbo.Paiements", t => t.IdPay)
                .ForeignKey("dbo.Personnes", t => t.IdPatient, cascadeDelete: true)
                .ForeignKey("dbo.Soins", t => t.IdSoin)
                .ForeignKey("dbo.Agenda", t => t.Agenda_IdAgenda)
                .Index(t => t.IdSoin)
                .Index(t => t.IdMoyenPay)
                .Index(t => t.IdPatient)
                .Index(t => t.IdPay)
                .Index(t => t.IdMedcin)
                .Index(t => t.Agenda_IdAgenda);
            
            CreateTable(
                "dbo.MoyenPayments",
                c => new
                    {
                        IdModePayment = c.Int(nullable: false, identity: true),
                        CodePayment = c.String(nullable: false, maxLength: 10, storeType: "nvarchar"),
                        Libelle = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        Reference = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.IdModePayment);
            
            CreateTable(
                "dbo.Paiements",
                c => new
                    {
                        IdPayment = c.Int(nullable: false, identity: true),
                        CodePay = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdPayment);
            
            CreateTable(
                "dbo.GroupeSanguins",
                c => new
                    {
                        IdGroupeSanguin = c.Int(nullable: false, identity: true),
                        CodeGroupeSanguin = c.String(nullable: false, maxLength: 3, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.IdGroupeSanguin);
            
            CreateTable(
                "dbo.Soins",
                c => new
                    {
                        IdSoin = c.Int(nullable: false, identity: true),
                        Description = c.String(unicode: false),
                        cout = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdSoin);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RendezVous", "Agenda_IdAgenda", "dbo.Agenda");
            DropForeignKey("dbo.RendezVous", "IdSoin", "dbo.Soins");
            DropForeignKey("dbo.RendezVous", "IdPatient", "dbo.Personnes");
            DropForeignKey("dbo.Personnes", "IdGroupeSanguin", "dbo.GroupeSanguins");
            DropForeignKey("dbo.RendezVous", "IdPay", "dbo.Paiements");
            DropForeignKey("dbo.RendezVous", "IdMoyenPay", "dbo.MoyenPayments");
            DropForeignKey("dbo.RendezVous", "IdMedcin", "dbo.Personnes");
            DropForeignKey("dbo.Personnes", "IdSpecialite", "dbo.Specialites");
            DropForeignKey("dbo.Agenda", "IdMedcin", "dbo.Personnes");
            DropForeignKey("dbo.Creneaux", "IdAgenda", "dbo.Agenda");
            DropIndex("dbo.RendezVous", new[] { "Agenda_IdAgenda" });
            DropIndex("dbo.RendezVous", new[] { "IdMedcin" });
            DropIndex("dbo.RendezVous", new[] { "IdPay" });
            DropIndex("dbo.RendezVous", new[] { "IdPatient" });
            DropIndex("dbo.RendezVous", new[] { "IdMoyenPay" });
            DropIndex("dbo.RendezVous", new[] { "IdSoin" });
            DropIndex("dbo.Personnes", new[] { "IdGroupeSanguin" });
            DropIndex("dbo.Personnes", new[] { "IdSpecialite" });
            DropIndex("dbo.Creneaux", new[] { "IdAgenda" });
            DropIndex("dbo.Agenda", new[] { "IdMedcin" });
            DropTable("dbo.Soins");
            DropTable("dbo.GroupeSanguins");
            DropTable("dbo.Paiements");
            DropTable("dbo.MoyenPayments");
            DropTable("dbo.RendezVous");
            DropTable("dbo.Specialites");
            DropTable("dbo.Personnes");
            DropTable("dbo.Creneaux");
            DropTable("dbo.Agenda");
        }
    }
}

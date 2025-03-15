namespace AppGestionRendezVous.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NomDeLaMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Personnes", "GroupeSangin");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Personnes", "GroupeSangin", c => c.String(maxLength: 3, storeType: "nvarchar"));
        }
    }
}

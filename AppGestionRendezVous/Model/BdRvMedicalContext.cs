using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  System.Data.Entity;
using MySql.Data.EntityFramework;

namespace AppGestionRendezVous.Model
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]

    public class BdRvMedicalContext : DbContext
    {
        public BdRvMedicalContext() : base("dbRvMedicalContext") { }
        
        public DbSet<Personne> Personnes { get; set; }
        public DbSet<Patient> Patients { get; set; }

        public DbSet<Medecin> Medecins { get; set; }

        public DbSet<Utilisateur> Utilisateurs { get; set; }

        public DbSet<Secretaire> Secretaires { get; set; }
         public DbSet<Agenda> Agendas { get; set; }

        public DbSet<RendezVous> RendezVous { get; set; }

        public DbSet<Specialite> Specialites { get; set; }

        public DbSet<GroupeSanguin> GroupeSanguins { get; set; }

        public DbSet<MoyenPayment> MoyenPayment { get; set; }
        public DbSet<Paiement> paiements { get; set; }
        public DbSet<Soin> soins { get; set; }
        public DbSet<Creneau> Creneaux { get; set; }
        public DbSet<Td_Erreur> td_Erreurs { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        
    }
}

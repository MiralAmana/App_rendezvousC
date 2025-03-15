using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionRendezVous.Model
{
    public class RendezVous
    {
        [Key]
        public int IdRendezVous { get; set; }

        public string Statut { get; set; }

        public DateTime DateRv { get; set; }= DateTime.Now;
        public string Creneau { get; set; }

        public string ReferencePayment { get; set; }

        public string NumRecu { get; set; }


        public int? IdSoin { get; set; }
        [ForeignKey("IdSoin")]
        public Soin Soin { get; set; }

        public int IdMoyenPay { get; set; }
        [ForeignKey("IdMoyenPay")]
        public MoyenPayment MoyenPayment { get; set; }

        public int IdPatient { get; set; }
        [ForeignKey("IdPatient")]
        public virtual Patient Patient { get; set; }


        public int? IdPay { get; set; }
        [ForeignKey("IdPay")]
        public Paiement Paiement { get; set; }


        public int? IdMedcin { get; set; }
        [ForeignKey("IdMedcin")]
        public Medecin Medecin { get; set; }
    }
}

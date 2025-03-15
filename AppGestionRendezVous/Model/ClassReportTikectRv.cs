using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionRendezVous.Model
{
    public class ClassReportTikectRv
    {
        public string NomPrenom {  get; set; }
       // public DateTime DateNaissance

        public DateTime DateRv { get; set; }

        public string Medecin { get; set; }

        public string Creneau { get; set; }
        public byte[] DataQr { get; set; }

        public string ReferencePayment { get; set; }

        public string soin { get; set; }

        public string cout { get; set; }

        public string NumRecu { get; set; }
       // public string ModePayment { get; set; }


    }
}

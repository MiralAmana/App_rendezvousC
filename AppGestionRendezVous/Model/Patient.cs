using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AppGestionRendezVous.Model
{
    public class Patient: Personne
    {
      
        [Required]
        public float? Poids {  get; set; }

        [Required]
        public float? Taille { get; set; }

        public int? IdGroupeSanguin { get; set; }
        [ForeignKey("IdGroupeSanguin")]
        public virtual GroupeSanguin GroupeSanguin { get; set; }
    }

}

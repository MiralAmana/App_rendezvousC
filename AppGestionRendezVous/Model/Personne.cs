using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AppGestionRendezVous.Model
{
    public class Personne
    {
        [Key]
        public int IdU { get; set; }

        [Required, MaxLength(200)]
        public string NomPrenom { get; set; }

        [Required,MaxLength(200), DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required,MaxLength(80)]
        public string Adresse { get; set; }

        [Required, MaxLength(20)]
        public string Tel { get; set; }
    }
}

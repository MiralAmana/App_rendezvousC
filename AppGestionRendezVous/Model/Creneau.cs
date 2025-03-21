﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionRendezVous.Model
{
    public class Creneau
    {
        [Key]
        public int IdCreneau { get; set; }

        public int IdAgenda { get; set; }   
        [ForeignKey("IdAgenda")]
        public virtual Agenda Agenda { get; set; } 

        public DateTime Date { get; set; } 
        public string HeureDebut { get; set; } 
        public string HeureFin { get; set; }   

        public bool Disponible { get; set; } 
    }
    }

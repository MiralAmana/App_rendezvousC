﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionRendezVous.Model
{
    public class Soin
    {
        [Key]
        public int IdSoin { get; set; } 

        public string Description { get; set; }

        public int cout { get; set; }
    }
}

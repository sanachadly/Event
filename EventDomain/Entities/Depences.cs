﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDomain.Entities
{
    public class Depences
    {

        [Key]
        public int DepenceID { get; set; }
        public string Objectif { get; set; }

        public float Valeur { get; set; }

        public string Description { get; set; }


        public int EventID { get; set; }




    }
}

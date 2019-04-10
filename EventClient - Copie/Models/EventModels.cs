using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventClient.Models
{
    public enum Categorie { Business, Entertainement, Occasion, Culture }

    public class EventModels
    {
        public int EventID { get; set; }
        public String Titre { get; set; }
        public Categorie Categorie { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public String Image { get; set; }
        public String Lieu { get; set; }
        public String Description { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace EventClient.Models
{
    public enum Categorie {Business,Entertainement,Occasion,Culture }
    public class EventViewModel
    {
        public int Id { get; set; }
        public String Titre { get; set; }
        public Categorie Categorie { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateDebut { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateFin { get; set; }
        public String Image { get; set; }
        public String Lieu { get; set; }
        public String Description { get; set; }
        public int reserver { get; set; }
        public int UserId { get; set; }
      //  public virtual ICollection<Task> Tasks { get; set; }
    }
}
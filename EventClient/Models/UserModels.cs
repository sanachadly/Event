using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventClient.Models
{
    public enum Role { Admin, Organisateur, Participant }

    public class UserModels
    {
        public int UserID { get; set; }
        public String Nom { get; set; }
        public String Prenom { get; set; }
        public DateTime DateNaissance { get; set; }
        public String Mail { get; set; }
        public Role Role { get; set; }
        public String Login { get; set; }
        public String MotDePasse { get; set; }
        public virtual ICollection<EventModels> Events { get; set; }
      //  public Ticket Ticket { get; set; }
      //  public virtual ICollection<Sondage> Sondages { get; set; }
    }
}
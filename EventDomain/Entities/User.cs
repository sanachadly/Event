using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDomain.Entities
{


    public enum Role { Admin, Organisateur, Participant }


   public  class User
    {

        public int UserID { get; set; }
        public String Nom { get; set; }
        public String Prenom { get; set; }
        public DateTime DateNaissance { get; set; }
        public String Mail { get; set; }
        public Role Role { get; set; }
        public String Login { get; set; }
        public String MotDePasse { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public Ticket Ticket { get; set; }
        public virtual ICollection<Sondage> Sondages { get; set; }


    }
}

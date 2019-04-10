using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDomain.Entities
{

    public enum Etat
    {
        Disponible, epuise
    }
    class Ticket
    {


        [Key]
        public int TicketID { get; set; }

        public Etat Etat { get; set; }
        public DateTime DateValidite { get; set; }

        public int NumberTicket { get; set; }



        //cle etranger
        public int UserID { get; set; }
        public int EventID { get; set; }
        public virtual Event Event { get; set; }



    }
}

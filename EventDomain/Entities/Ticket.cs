using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDomain.Entities
{
  public  class Ticket
    {

        public int TicketID { get; set; }
        public DateTime DateValidite { get; set; }
        //cle etranger
        public int UserID { get; set; }
        public int EventID { get; set; }
      //  public User User { get; set; }




    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDomain.Entities
{
    public class Reservation
    {
        public int ReservationID { get; set; }
        //cle etrangere
        public int UserID { get; set; }
        public DateTime DateReservation { get; set; }


    }
}

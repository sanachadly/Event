using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventClient.Models
{
    public class ReservationViewModel
    {
        public int ReservationID { get; set; }
        //cle etrangere
        public int UserID { get; set; }
        public DateTime DateReservation { get; set; }
    }
}
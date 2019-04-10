using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventClient.Models
{
    public class TicketViewModel
    {
        [Key]
        public int TicketID { get; set; }
        public EventViewModel Event { get; set; }
        public DateTime DateValidite { get; set; }
        public int NumberTicket { get; set; }

        //cle etranger
        public int UserID { get; set; }
        public int EventID { get; set; }

        //  public User User { get; set; }


        public class IndexViewModel
        {
            public string StripePublishableKey { get; set; }
        }
        public class ChargeViewModel
        {
            public string StripeToken { get; set; }
            public string StripeEmail { get; set; }
        }

        public class CustomViewModel
        {
            public string StripePublishableKey { get; set; }
            public string StripeToken { get; set; }
            public string StripeEmail { get; set; }
            public bool PaymentForHidden { get; set; }
            public string PaymentForHiddenCss
            {
                get
                {
                    return PaymentForHidden ? "hidden" : "";
                }
            }


        }
    }



}

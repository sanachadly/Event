using System;

namespace EventDomain.Entities
{
    public class Task
    {

        public int TaskID { get; set; }
        public String Objet { get; set; }
        public DateTime DateLimite { get; set; }
        //2 cles etrangeres
        public int EventFK { get; set; }
        public int UserFK { get; set; }

        public Event EventID { get; set; }
        public User UserID { get; set; }

    }
}

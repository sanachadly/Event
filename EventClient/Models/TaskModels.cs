using System;
using System.ComponentModel.DataAnnotations;

namespace EventClient.Models
{
    public class TaskModels
    {
        [Key]
        public int TaskID { get; set; }
        public String Objet { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateLimite { get; set; }
        public int EventFK { get; set; }
        public int UserFK { get; set; }

        public EventModels EventID { get; set; }
        public UserModels UserID { get; set; }
    }
}
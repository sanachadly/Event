using EventDomain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventClient.Models
{

    public enum Categorie { Business, Entertainement, Occasion, Culture }
    public class EventViewModel
    {

        [Key]
        public int EventID { get; set; }
        public String Title { get; set; }
        public float Price { get; set; }
        public Categorie Categorie { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public String Image { get; set; }
        public String place { get; set; }
        public String Description { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }


     


    }




    



        

    }

using EventDomain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
  public  class Context:DbContext
    {



        public Context() : base("name=BD")
        {
          


        }
        public DbSet<Event> Evenements { get; set; }

        //CONVENTION ET CONFIGURATION
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Event>().ToTable("Event");
            //  modelBuilder.Conventions.Add(new KeyConvention());
            //  modelBuilder.Conventions.Add(new DateTimeConvention());

        }

    }







}

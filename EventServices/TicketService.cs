using Data.Infrastructure;
using EventDomain.Entities;

using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EventServices
{
   public class TicketService : Service<Ticket>,ITicketService


    {
        private static IDatabaseFactory databaseFactory = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(databaseFactory);



        public TicketService():base(ut)
        {
            
        }




        // User could just paye Ticket which are disponible 

            // liste des ticket qui ont les etat disponnible etqui sont ordonné suivant leur datedevalidation 
       //public IEnumerable<Ticket> listTicket()
       // {
       //      return GetAll().Where(t=>t.Etat== Etat.Disponible).OrderBy(e => e.DateValidite);


       // }


        //public IEnumerable<Ticket> TGetId(int id)
        //{
        //    return (IEnumerable<Ticket>)GetAll().Where(t => t.EventID == id);


        //}



    }



}

using Data.Infrastructure;
using EventDomain.Entities;
using EventServicePatern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventServices
{
   public class ReservationService : Service<Reservation>, IReservationService
    {
        private static IDatabaseFactory databaseFactory = new DatabaseFactory();
        private static IUnitOfWork unit = new UnitOfWork(databaseFactory);
        public ReservationService() : base(unit)
        {
         
        }
        public string isReserved(int idU , int idE)
        {
            var r = GetAll();
            var x = (from i in r where i.EventId==idE && i.UserID==idU select i);
            if(x.Count() ==0)
            {
                return "false";
            }
            else
            {
                return "true";
            }

        }
        public Reservation getByUE(int idU, int idE)
        {
            var r = GetAll();
            var x = (from i in r where i.EventId == idE && i.UserID == idU select i);
            return x.First();
        }
    }
}
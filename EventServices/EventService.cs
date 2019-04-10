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
   public class EventService : Service<Event>,IEventService
    {
        private static IDatabaseFactory databaseFactory = new DatabaseFactory();
        private static IUnitOfWork unit = new UnitOfWork(databaseFactory);
        public EventService() : base(unit)
        {

        }
    }
}

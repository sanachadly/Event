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
   public class EventService : Service<Event>,IEventService
    {
        private static IDatabaseFactory databaseFactory = new DatabaseFactory();
        private static IUnitOfWork unit = new UnitOfWork(databaseFactory);
        public EventService() : base(unit)
        {

        }

        //public List<Event> BestOf()
        //{
            //List<Event> totalEvent = GetAll().ToList();
            //List<Event> topEvent = new List<Event>();
            //for (int i = 0; i < 3; i++)
            //{

            //    float max = pourcentageGain(totalEvent[0]);

            //    Event current = totalEvent[0];
            //    foreach (Event e in totalEvent)
            //    {
            //        if (pourcentageGain(e) > max)
            //        {
            //            max = pourcentageGain(e);
            //            current = e;
            //        }
            //    }
            //    topEvent.Add(current);
            //    totalEvent.Remove(current);
            //}
            //return topEvent;

        }

        //public float pourcentageGain(Event e)
        //{
        //    ////float revenue = e.Price * e.Tickets.Count();
        //    //float totaldepence = sumDepence(e);
        //    //return ((revenue - totaldepence) / totaldepence) * 100;
        //}

        //public float revenueNet(Event e)
        //{
        //    //float revenue = e.Price * e.Tickets.Count();
        //    //float totaldepence = sumDepence(e);

        //    //return revenue - totaldepence;

        //}

    //    public float sumDepence(Event e)
    //    {
    //        float totalDepence = 0;
    //        foreach (Depences dep in e.dep)
    //        {
    //            totalDepence += dep.Valeur;
    //        }
    //        return totalDepence;
    //    }
    //}
}

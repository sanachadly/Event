using EventDomain.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventServices
{
   public interface IEventService: IService<Event>
    {
        float sumDepence(Event e);
        float revenueNet(Event e);

        float pourcentageGain(Event e);

        List<Event> BestOf();
    }
}

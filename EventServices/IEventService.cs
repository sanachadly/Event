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
    }
}

using EventDomain.Entities;
using EventServicePatern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventServices
{
  public  interface IReservationService : IService<Reservation>
    {
    }
}

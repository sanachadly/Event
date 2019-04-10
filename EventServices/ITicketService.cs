using EventDomain.Entities;
using EventServicePatern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventServices
{
   public interface ITicketService :IService<Ticket> 
    {
        IEnumerable<Ticket> TGetId(int id);


    }

   
}

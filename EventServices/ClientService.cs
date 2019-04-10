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
    public class ClientService:Service<Client>
    {

        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);
        public ClientService():base(ut)
          
        {

        }

    }
}

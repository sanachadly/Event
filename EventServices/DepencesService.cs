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
  public   class DepencesService :Service<Depences>,IDepencesService
    {


        private static IDatabaseFactory databaseFactory = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(databaseFactory);



        public DepencesService() : base(ut)
        {

        }

      
    }
}

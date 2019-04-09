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


    public class UserService : Service<User>
    {
        private static IDatabaseFactory dbfactory = new DatabaseFactory();
        public static IUnitOfWork ut = new UnitOfWork(dbfactory);
        public UserService() : base(ut)
        {

        }
    }
}

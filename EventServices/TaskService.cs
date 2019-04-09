
using Data.Infrastructure;
using EventDomain.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace EventServices
{
    public   class TaskService: Service<Task>,ITaskService
    {
     private static  IDatabaseFactory dbfactory = new DatabaseFactory();
     public static   IUnitOfWork ut = new UnitOfWork(dbfactory);
        public TaskService():base(ut)
        {

        }
    }
}

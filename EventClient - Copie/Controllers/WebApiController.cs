using EventClient.Models;
using EventServices;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EventClient.Controllers
{
    [RoutePrefix("api/Event")]
    public class WebApiController : ApiController
    {

        ITaskService ps = null;

        public WebApiController()
        {
            ps = new TaskService();
        }
        [HttpGet]
        [Route("GetTasks")]
        public List<TaskModels> GetTasks()
        {
            var taskk =ps.GetAll();

            List<TaskModels> fVM = new List<TaskModels>();
            foreach (var item in taskk)
            {

                fVM.Add(new TaskModels
                {
                    TaskID = item.TaskID,
                    Objet = item.Objet,
                    DateLimite = item.DateLimite,
                    EventFK = item.EventFK,
                    UserFK = item.UserFK
                });
            }
            return fVM;
        }
    }
}

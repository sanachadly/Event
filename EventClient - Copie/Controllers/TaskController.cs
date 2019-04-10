using EventClient.Models;
using EventDomain.Entities;
using EventServices;
using Rotativa.MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventClient.Controllers
{
    public class TaskController : Controller
    {
        ITaskService TS = null;
        IEventService ES = null;
        UserService US = null;
        public TaskController()
        {
            TS = new TaskService();
            ES = new EventService();
            US = new UserService();
        }

       
        // GET: Task
        public ActionResult Index()
        {
            
            var tasks = TS.GetAll();
            List<TaskModels> taskModels = new List<TaskModels>();
            foreach (var item  in tasks)
            {
                taskModels.Add(new TaskModels
                {
                    TaskID = item.TaskID,
                    Objet = item.Objet,
                    DateLimite = item.DateLimite,
                    EventFK = item.EventFK,
                    UserFK = item.UserFK                    
                });
                
            }
            List<UserModels> userModels = new List<UserModels>();
            foreach (var it in US.GetAll())
            {
                userModels.Add(new UserModels
                {
                    UserID = it.UserID,
                    Nom = it.Nom
                });

            }
            ViewBag.users = userModels;
            List<EventModels> eventModels = new List<EventModels>();

            foreach (var it in ES.GetAll())
            {
                eventModels.Add(new EventModels
                {
                    Titre = it.Titre,
                    EventID = it.EventID
                });

            }
            ViewBag.task = eventModels;
            return View(taskModels);
        }
        public ActionResult Index2()
        {


            var tasks = TS.GetAll();
            List<TaskModels> taskModels = new List<TaskModels>();
            foreach (var item in tasks)
            {
                taskModels.Add(new TaskModels
                {
                    TaskID = item.TaskID,
                    Objet = item.Objet,
                    DateLimite = item.DateLimite,
                    EventFK = item.EventFK,
                    UserFK = item.UserFK

                });

            }

            return View(taskModels);
        }

        public ActionResult PrintViewToPdf()
        {
            var report = new ActionAsPdf("Index2");
            return report;
        }
        [HttpPost]
        public ActionResult Index(string searchString)
        {
            
            var tasks = TS.GetAll();
            List<TaskModels> taskModels = new List<TaskModels>();
            foreach (var item in tasks)
            {
                
                taskModels.Add(new TaskModels
                {
                    TaskID = item.TaskID,
                    Objet = item.Objet,
                    DateLimite = item.DateLimite,
                    EventFK = item.EventFK,
                    UserFK = item.UserFK,
                   
                });
                
            }
            List<EventModels> eventModels = new List<EventModels>();

            foreach (var it in ES.GetAll())
            {
                eventModels.Add(new EventModels
                {
                    Titre = it.Titre,
                    EventID = it.EventID
                });

            }
            ViewBag.task = eventModels;

            List<UserModels> userModels = new List<UserModels>();
            foreach (var it in US.GetAll())
            {
                userModels.Add(new UserModels
                {
                   UserID = it.UserID,
                    Nom = it.Nom

                });

            }
            ViewBag.users = userModels;

            if (!String.IsNullOrEmpty(searchString))
            {


                taskModels = taskModels.Where(c => c.Objet == searchString).ToList();


                return View(taskModels);

            }
         


            return View(taskModels);
        }


        // GET: Task/Details/5
        public ActionResult Details(int id)
        {
            Task task = TS.GetById(id);
            TaskModels bvm = new TaskModels();
            bvm.TaskID = task.TaskID;
            bvm.Objet = task.Objet;
            bvm.DateLimite = task.DateLimite;
            bvm.EventFK = task.EventFK;
            bvm.UserFK = task.UserFK;
     

            Event e = ES.GetById(task.EventFK);
            User u = US.GetById(task.UserFK);
               EventModels eventModels =new EventModels
                {
                    Titre = e.Titre,
                    EventID = e.EventID
                };
            UserModels userModels = new UserModels
            {
                Nom = u.Nom,
                UserID = u.UserID
            };
            ViewBag.us = userModels.Nom;
            ViewBag.ev = eventModels.Titre;
            return View(bvm);
        }

        // GET: Task/Create
        public ActionResult Create()
        {
            ViewBag.events = new SelectList(ES.GetAll(), "EventID"/*Key*/, "Titre"/*value*/);
            ViewBag.users = new SelectList(US.GetAll(), "UserID"/*Key*/, "Nom"/*value*/);
            return View();
        }

        // POST: Task/Create
        [HttpPost]
        public ActionResult Create(TaskModels tm)
        {
            Task T = new Task
            {
                Objet = tm.Objet,
                DateLimite = tm.DateLimite,
                EventFK = tm.EventFK,
                UserFK = tm.UserFK
            };
            TS.Add(T);
            TS.Commit();


            return RedirectToAction("Index");

        }

        // GET: Task/Edit/5
        public ActionResult Edit(int id)
        {
            var task = TS.GetById(id);


            TaskModels bvm = new TaskModels();
            bvm.TaskID = task.TaskID;   
            bvm.Objet = task.Objet;
            bvm.DateLimite = task.DateLimite;
            bvm.EventFK = task.EventFK;
            bvm.UserFK = task.UserFK;


            ViewBag.events = new SelectList(ES.GetAll(), "EventID"/*Key*/, "Titre"/*value*/);
            ViewBag.users = new SelectList(US.GetAll(), "UserID"/*Key*/, "Nom"/*value*/);


            return View(bvm);
        }

        // POST: Task/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TaskModels taskModel)
        {
           Task task = TS.GetById(id);
            task.DateLimite = taskModel.DateLimite;
            task.Objet = taskModel.Objet;
            task.EventFK = taskModel.EventFK;
            task.UserFK = taskModel.UserFK;
            TS.Update(task);
            TS.Commit();

            return RedirectToAction("Index");

        }

        // GET: Task/Delete/5
        public ActionResult Delete(int id)
        {
            Task e = TS.GetById(id);
            TS.Delete(e);
            TS.Commit();
            return RedirectToAction("Index");
        }

        // POST: Task/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }
    }
}

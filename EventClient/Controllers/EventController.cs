using EventClient.Models;
using EventDomain.Entities;
using EventServices;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace EventClient.Controllers
{
    public class EventController : Controller
    {
        // GET: Event
        EventService es = new EventService();
        ReservationService rs = new ReservationService();
        public ActionResult Index()
        {
            
            List<EventViewModel> lists = new List<EventViewModel>();
            foreach (var item in es.GetAll())
            {
                EventViewModel evm = new EventViewModel();
                evm.Id= item.EventID;
                evm.DateDebut = item.DateDebut;
                evm.DateFin = item.DateFin;
     
                evm.Image = item.Image;
                evm.UserId = item.UserId;
              
              evm.Categorie = (EventClient.Models.Categorie)item.Categorie;
                if (rs.isReserved(1, item.EventID).Equals("true"))
                {
                    evm.reserver = 1;
                }
                else
                {
                    evm.reserver = 0;
                }
                lists.Add(evm);

            }
            return View(lists);
        }
        [HttpPost]
        public ActionResult Index(string searchString)
        {

            List<EventViewModel> lists = new List<EventViewModel>();
            foreach (var item in es.GetAll())
            {
                EventViewModel evm = new EventViewModel();
                evm.Id = item.EventID;
                evm.DateDebut = item.DateDebut;
                evm.DateFin = item.DateFin;
                evm.Description = item.Description;
                evm.Image = item.Image;
                evm.UserId = item.UserId;
                evm.Lieu = item.Lieu;
                evm.Titre = item.Titre;
                evm.Categorie = (EventClient.Models.Categorie)item.Categorie;
                if (rs.isReserved(1, item.EventID).Equals("true"))
                {
                    evm.reserver = 1;
                }
                else
                {
                    evm.reserver = 0;
                }
                lists.Add(evm);
            }
            
        
                if (!String.IsNullOrEmpty(searchString))
                {


                    lists = lists.Where(c => c.Titre== searchString).ToList();


                    return View(lists);

                


            }
            return View(lists);
        }
        // GET: Event/Details/5
        public ActionResult Details(int id)
        {


            Event e = es.GetById(id);
            EventViewModel evm = new EventViewModel();
            evm.Id = e.EventID;
            evm.DateDebut = e.DateDebut;
            evm.DateFin = e.DateFin;
            evm.Description = e.Description;
            evm.Image = e.Image;
            evm.UserId = 1;
            evm.Lieu = e.Lieu;
            evm.Titre = e.Titre;
           
            return View(evm);
        }

       

           

            Image.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), Image.FileName));
            es.Add(e);
            es.Commit();
            return RedirectToAction("Index");
            
        }

        // GET: Event/Edit/5
        public ActionResult Edit(int id)
        {
            Event e = es.GetById(id);
            EventViewModel evm = new EventViewModel();
            evm.Id = e.EventID;
            evm.DateDebut = e.DateDebut;
            evm.DateFin = e.DateFin;
            evm.Description = e.Description;
            evm.Image = e.Image;
            evm.UserId = e.UserId;
            evm.Lieu = e.Lieu;
            evm.Titre = e.Titre;
            evm.Categorie = (EventClient.Models.Categorie)e.Categorie;
            return View(evm);
        }

        // POST: Event/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EventViewModel evm, HttpPostedFileBase Image)
        {

           
            Event e = es.GetById(id);
            e.EventID = id;
            e.DateDebut = evm.DateDebut;
            e.DateFin = evm.DateFin;
            e.Description = evm.Description;
            e.Image = Image.FileName;
            e.Titre = evm.Titre;
            e.Lieu = evm.Lieu;
            e.Categorie = (EventDomain.Entities.Categorie)evm.Categorie;
           
            es.Update(e);
           // Image.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), Image.FileName));
            es.Commit();
            return RedirectToAction("Index");
           
        }

        // GET: Event/Delete/5
        public ActionResult Delete(int id)
        {
            Event e = es.GetById(id);
            es.Delete(e);
            es.Commit();
            return RedirectToAction("Index");
        }

        // POST: Event/Delete/5
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
        public ActionResult CreateRes(int id)
        {
            Reservation r = new Reservation();
            r.DateReservation = DateTime.Now.ToString();
            r.UserID = 1;
            r.EventId = id;
            rs.Add(r);
            rs.Commit();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteRes(int id)
        {

            var r = rs.getByUE(1, id);
            rs.Delete(r);
            rs.Commit();
            return RedirectToAction("Index");
        }
        
    }
}

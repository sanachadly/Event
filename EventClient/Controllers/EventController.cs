using EventClient.Models;
using EventServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventClient.Controllers
{
    public class EventController : Controller
    {

        EventService es = new EventService();
        // GET: Event
        public ActionResult Index()
        {

            var Event = es.GetAll();

            List<EventViewModel> liste = new List<EventViewModel>();
            foreach (var item in Event)
            {
                liste.Add(
                    new EventViewModel
                    {
                        EventID = item.EventID,
                        Title= item.Titre,
                        Description = item.Description,
                        place = item.Lieu,
                        StartDate = item.DateDebut,
                        EndDate=item.DateFin,
                        Image=item.Image,
                        Price = item.Price
                    });
            }

            return View(liste);
        }

        public ActionResult Best()
        {

            var Event = es.BestOf();

            List<EventViewModel> liste = new List<EventViewModel>();
            foreach (var item in Event)
            {
                liste.Add(
                    new EventViewModel
                    {
                        EventID = item.EventID,
                        Title = item.Title,
                        Description = item.Description,
                        place = item.place,
                        StartDate = item.StartDate,
                        EndDate = item.EndDate,
                        Image = item.Image,
                        Price = item.Price
                    });
            }

            return View(liste);
        }

        // GET: Event/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Event/View/5
        public ActionResult View (int id)
        {
            //var v = ds.GetById(id);
            RapportModel rapport = new RapportModel();
            //DepencesViewModel dvm = new DepencesViewModel();
            rapport.TotalDepence = es.sumDepence(es.GetById(id));
            rapport.RevenueNet = es.revenueNet(es.GetById(id));
            rapport.PourcentageGain = es.pourcentageGain(es.GetById(id));



            return View(rapport);
        }

        // GET: Event/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Event/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Event/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Event/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Event/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
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
    }
}

using EventClient.Models;
using EventDomain.Entities;
using EventServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventClient.Controllers
{
    public class DepencesController : Controller
    {

        DepencesService ds = new DepencesService();


        // GET: Depences
        public ActionResult Index()
        {
            var depences = ds.GetAll();
            
             List<DepencesViewModel> liste = new List<DepencesViewModel>();
            foreach (var item in depences)
            {
                liste.Add(
                    new DepencesViewModel
                    {
                        DepenceID = item.DepenceID,
                        Objectif = item.Objectif,
                        Description = item.Description,
                        Valeur = item.Valeur,
                        EventID = item.EventID    
                    });
            }

            return View(liste);
             
        
        }

        // GET: Depences/Details/5
        public ActionResult Details(int id)
        {
            var v = ds.GetById(id);
            DepencesViewModel dvm = new DepencesViewModel();
            dvm.Objectif = v.Objectif;
            dvm.Description = v.Description;
            dvm.Valeur = v.Valeur;
            dvm.EventID = v.EventID;
          

            return View(dvm);
        }

        // GET: Depences/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Depences/Create
        [HttpPost]
        public ActionResult Create(DepencesViewModel dvm)
        {

            Depences d = new Depences();
            d.DepenceID = dvm.DepenceID;
            d.Description = dvm.Description;
            d.Objectif = dvm.Objectif;
            d.Valeur = dvm.Valeur;
            d.EventID = dvm.EventID;
           
            ds.Add(d);

            ds.Commit();
            return RedirectToAction("Index");

        }

        // GET: Depences/Edit/5
        public ActionResult Edit(int id)
        {
            var v = ds.GetById(id);
            DepencesViewModel dvm = new DepencesViewModel();
            dvm.Objectif = v.Objectif;
            dvm.Valeur = v.Valeur;
            dvm.Description = v.Description;
            dvm.EventID = v.EventID;

            return View(dvm);
        }

        // POST: Depences/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DepencesViewModel dvm)
        {
            Depences d = ds.GetById(id);

            d.Objectif =dvm.Objectif;
            d.Valeur = dvm.Valeur;
            d.Description = dvm.Description;
            d.EventID = dvm.EventID;


            ds.Update(d);
            ds.Commit();
            return RedirectToAction("Index");
        }

        // GET: Depences/Delete/5
        public ActionResult Delete(int id)
        {

            return View();
        }

        // POST: Depences/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, DepencesViewModel dvm)
        {
         //les info 
            Depences d = ds.GetById(id);
           // d.DepenceID = dvm.DepenceID;
            d.Objectif = dvm.Objectif;
            d.Valeur = dvm.Valeur;
            d.Description = dvm.Description;
           

            ds.Delete(d);
            ds.Commit();
            return RedirectToAction("Index");
           
          
        }
    }
}

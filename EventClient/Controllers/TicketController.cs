using EventClient.Models;
using EventDomain.Entities;
using EventServices;
using Stripe;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Web.Mvc;
using static EventClient.Models.TicketViewModel;

namespace EventClient.Controllers
{
    public class TicketController : Controller
    {

        // EventServices.EventService Es = new EventServices.EventService();

      ITicketService  TiS = new TicketService();


        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult Charge(ChargeViewModel chargeViewModel)
        {
            Debug.WriteLine(chargeViewModel.StripeEmail);
            Debug.WriteLine(chargeViewModel.StripeToken);

            return RedirectToAction("Confirmation");

        }


        public ActionResult Confirmation()
        {
            return RedirectToAction("Index"); ;
        }


        public ActionResult Custom()
        {
            string stripePublishableKey = ConfigurationManager.AppSettings["stripePublishableKey"];
           var model = new CustomViewModel() { StripePublishableKey = stripePublishableKey, PaymentForHidden = true };
            return View(model);
        }


        public ActionResult Charge(string stripeEmail, string stripeToken)
        {
           // EventService e = new EventService();
            var customers = new CustomerService();
            var charges = new ChargeService();

            var customer = customers.Create(new CustomerCreateOptions
            {
                Email = stripeEmail,
                SourceToken = stripeToken
            });
            EventDomain.Entities.Event e = new EventDomain.Entities.Event();

            var charge = charges.Create(new ChargeCreateOptions
            {
                Amount = 500,
               // Amount = e.Price,
                Description = "Sample Charge",
                Currency = "usd",
                CustomerId = customer.Id
            });

           return RedirectToAction("TicketSys");
        }

        public ActionResult Index2()
        {


            var stripePublishKey = ConfigurationManager.AppSettings["pk_test_7q4n9YPyKbELVrV2ZhnZvnif00EPrbMWqj"];
            ViewBag.StripePublishKey = stripePublishKey;
            return View();
        }



        public ActionResult Index3()
        {

            return View();
        }

        public ActionResult Error()
        {
            return View();

        }









        // GET: Ticket

        TicketService ts = new TicketService();
        // GET: Meeting
        public ActionResult Index()
        {

            var getAll = ts.GetAll();
            return View(getAll);
        }







        public ActionResult Details(int id)
        {
            var v = ts.GetById(id);
            TicketViewModel tvm = new TicketViewModel();
            tvm.DateValidite = v.DateValidite;
            tvm.NumberTicket= v.NumberTicket;
            tvm.EventID = v.EventID;

            return View(tvm);
        }


        //create qui va recuperer les champ de titre et nom de user





        // GET: Ticket/Create
        //public ActionResult Create()
       // {

           // var b = ts.GetAll();
          //  foreach (var item in b)
           // {



              //  EventViewModel Evm = new EventViewModel();

                

          //  }

          //  return View();
       // }







        // GET: Ticket/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Create
        [HttpPost]

        public ActionResult Create(TicketViewModel tvm)
        {
            {

           
                Ticket T = new Ticket();
                T.TicketID = tvm.TicketID;
                T.DateValidite = tvm.DateValidite;
                T.UserID = tvm.UserID;
                T.EventID = tvm.EventID;
                T.NumberTicket = tvm.NumberTicket;
                ts.Add(T);

                ts.Commit();
                return RedirectToAction("Index");
            }

        }


        // GET: Ticket/Edit/5
        public ActionResult Edit(int id)
        {
            var v = ts.GetById(id);
            TicketViewModel tvm = new TicketViewModel();
            tvm.DateValidite = v.DateValidite;
            tvm.NumberTicket = v.NumberTicket;

            tvm.EventID = v.EventID;

            return View(tvm);

        }

        // POST: Meeting/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TicketViewModel tvm)
        {
            Ticket t = ts.GetById(id);

            t.DateValidite = tvm.DateValidite;
            t.NumberTicket = tvm.NumberTicket;
            t.EventID = tvm.EventID;

            ts.Update(t);
            ts.Commit();
            return RedirectToAction("Index");
        }

        // GET: Ticket/Delete/5
        public ActionResult Delete(int id)
        {

          ///  TicketService ts = TiS.GetById(id);
            ///TicketViewModel tvmm = new TicketViewModel();
            //tvmm.DateValidite = TiS.
                //VisitReason visitservice = VRS.GetById(id);



            // VisitReasonViewModel vrvm = new VisitReasonViewModel();
            // vrvm.VRDescription = visitservice.VRDescription;
            // vrvm.VRId = visitservice.VRId;
            //  vrvm.DoctorId = visitservice.DoctorId;
            // return View(vrvm);

            return View();
        }

        // POST: Ticket/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, TicketViewModel tvm)
        {


            Ticket t = ts.GetById(id);
           // t.TicketID = tvm.TicketID;
            t.DateValidite = tvm.DateValidite;
            t.NumberTicket = tvm.NumberTicket;
            t.EventID = tvm.EventID;

            ts.Delete(t);
            ts.Commit();
            return RedirectToAction("Index");
        }




        [HttpPost]
        public ActionResult SearchTicket(string search)
        {
            List<TicketViewModel> list = new List<TicketViewModel>(); //il faut instancier  liste des view model khater fih  eli amlnelhom creation
            var a = ts.GetAll();
            foreach (var i in a) //kol mara f list hedhika tafichili hadhika
            {

                //nomcomplet view model khater kaadin nekhdmou bl view model mch bl model 

                TicketViewModel tvm = new TicketViewModel();

                tvm.DateValidite = i.DateValidite;
                tvm.EventID = i.EventID;
                tvm.UserID = i.UserID;

                // avm.nomComplet = new NomCompletViewModel() { Nom = i.nomComplet.Nom, Prenom = i.nomComplet.Prenom };

                list.Add(tvm); /// bch nhothom f lista 


            }

            if (!string.IsNullOrEmpty(search))
            {

                //   list = list.Where(e => e.UserID.Contains(search)).ToList();
            }


            return View(list); // je vais retourner la liste    
            


        }



        // GET: Form/Create
        public ActionResult TicketSys(EventViewModel ti)
        {

            Formulaire f = new Formulaire();
           // EventService es = new EventService();
            TicketService Tk = new TicketService();
            Formulaire form = new  Formulaire ();
            
             EventViewModel E = new EventViewModel();
             E.Title = ti.Title;
             E.place = ti.place;
             E.StartDate = DateTime.Today;
             E.Price = ti.Price;

           // f.PseudoName=
        

            
            //return RedirectToAction("Index3");
            





            //EventDomain.Entities.User u = es.Get(a => a.Title == mm.Title);


            return View();
        }

        // GET: Form/Create
        //public ActionResult CreateF()
       // {

           // EventViewModel Avm = new EventViewModel();

           // var producers = Avm.GetAll();

            //ViewBag.myproducer =
               /// new SelectList(producers, "Title", "Title");
            //return View();

      //  }

        // [HttpPost]
     //   public ActionResult CreateFormu (EventViewModel Evm)
        //{
        //
         //   EventViewModel E = new EventViewModel();
          //  List<EventViewModel> Es = new List<EventViewModel>();
            


            
          //  E.Titre = Evm.Titre;
           // E.Lieu = Evm.Lieu;
          //  E.DateDebut = DateTime.Today;
           // E.Price = Evm.Price;
           // EventDomain.Entities.User u = ES.Get(a => a.Title == mm.Title);


         //   ts.Commit();
           // return RedirectToAction("Index");




           // return RedirectToAction("Index3");

      //  }
      //  {

         //   List<EventViewModel> listEv = new List<EventViewModel>();
           // var a = Es.GetAll();
           /// foreach (var i in a) //kol mara f list hedhika tafichili hadhika
           // {
               // EventViewModel Evm = new EventViewModel();
               // Evm.Titre = i.Titre;
                //Evm.Lieu = i.Lieu;
                //Evm.DateDebut = DateTime.Today;
               // Evm.Price = i.Price;

               // return View();
          //  }
      //  }









    }
}
                

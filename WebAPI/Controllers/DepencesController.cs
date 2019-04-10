using ClientApi.Models;
using EventDomain.Entities;
using EventServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebAPI.Controllers
{
    public class DepencesController : ApiController
    {
        DepencesService MS = new DepencesService();
        // GET: api/DepenceAPI
        [HttpGet]
        public IQueryable<Depences> GetDepences()
        {
            return MS.GetAll().AsQueryable();
        }
        [ResponseType(typeof(Depences))]

        // GET: api/DepenceAPI/5
        [HttpGet]
        public IHttpActionResult GetOneDepence(int id)
        {
            Depences M = MS.GetById(id);
            if (M == null)
            {
                return NotFound();
            }

            return Ok(M);
        }

        // POST: api/DepenceAPI
        [HttpPost]
        public IHttpActionResult Post([FromBody]DepencesApiViewModel MVMA)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            Depences M = new Depences();
            M.DepenceID = MVMA.DepenceID;
            M.Description = MVMA.Description;
            M.EventID = MVMA.EventID;
            M.Objectif = MVMA.Objectif;
            M.Valeur = MVMA.Valeur;
            MS.Add(M);
            MS.Commit();
            return Ok(M);
        }

        // PUT: api/DepencesAPI/5
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] DepencesApiViewModel MVMA)
        {
            Depences M = MS.GetById(id);
            M.Description = MVMA.Description;
            M.Objectif = MVMA.Objectif;
            M.Valeur = MVMA.Valeur;
            MS.Update(M);
            MS.Commit();
            return Ok();
        }

        // DELETE: api/DepencesAPI/5
        [HttpDelete]
        public IHttpActionResult Delete(int id, [FromBody]DepencesApiViewModel MVMA)
        {
            Depences M = MS.GetById(id);
            M.Description = MVMA.Description;
            M.Objectif = MVMA.Objectif;
            M.Valeur = MVMA.Valeur;

            MS.Delete(M);
            MS.Commit();

            return Ok();
        }




    }



}

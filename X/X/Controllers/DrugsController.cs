using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using X.Models;

namespace X.Controllers
{
    public class DrugsController : ApiController
    {
        private XModelContainer db = new XModelContainer();

        // GET: api/Drugs
        public IQueryable<Drug> GetDrugSet()
        {
            foreach (var drug in db.DrugSet)
            {
                foreach ( var unit in drug.UnitsOfMeasurement)
                {
                    var str = unit.ToString();
                }
            }
            return db.DrugSet;
        }

        // GET: api/Drugs/5
        [ResponseType(typeof(Drug))]
        public IHttpActionResult GetDrug(int id)
        {
            Drug drug = db.DrugSet.Find(id);
            if (drug == null)
            {
                return NotFound();
            }

            return Ok(drug);
        }

        // PUT: api/Drugs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDrug(int id, Drug drug)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != drug.Id)
            {
                return BadRequest();
            }

            db.Entry(drug).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrugExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Drugs
        [ResponseType(typeof(Drug))]
        public IHttpActionResult PostDrug(Drug drug)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DrugSet.Add(drug);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = drug.Id }, drug);
        }

        // DELETE: api/Drugs/5
        [ResponseType(typeof(Drug))]
        public IHttpActionResult DeleteDrug(int id)
        {
            Drug drug = db.DrugSet.Find(id);
            if (drug == null)
            {
                return NotFound();
            }

            db.DrugSet.Remove(drug);
            db.SaveChanges();

            return Ok(drug);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DrugExists(int id)
        {
            return db.DrugSet.Count(e => e.Id == id) > 0;
        }
    }
}
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
    public class DrugSupliesController : ApiController
    {
        private XModelContainer db = new XModelContainer();

        // GET: api/DrugSuplies
        public IQueryable<DrugSuply> GetDrugSuplySet()
        {
            var l = db.DrugSuplySet.ToList();
            return db.DrugSuplySet;
        }

        // GET: api/DrugSuplies/5
        [ResponseType(typeof(DrugSuply))]
        public IHttpActionResult GetDrugSuply(int id)
        {
            DrugSuply drugSuply = db.DrugSuplySet.Find(id);
            if (drugSuply == null)
            {
                return NotFound();
            }

            return Ok(drugSuply);
        }

        // PUT: api/DrugSuplies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDrugSuply(int id, DrugSuply drugSuply)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != drugSuply.Id)
            {
                return BadRequest();
            }

            db.Entry(drugSuply).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrugSuplyExists(id))
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

        // POST: api/DrugSuplies
        [ResponseType(typeof(DrugSuply))]
        public IHttpActionResult PostDrugSuply(DrugSuply drugSuply)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            drugSuply.DeliveryTime = DateTime.Now;

            db.DrugSuplySet.Add(drugSuply);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = drugSuply.Id }, drugSuply);
        }

        // DELETE: api/DrugSuplies/5
        [ResponseType(typeof(DrugSuply))]
        public IHttpActionResult DeleteDrugSuply(int id)
        {
            DrugSuply drugSuply = db.DrugSuplySet.Find(id);
            if (drugSuply == null)
            {
                return NotFound();
            }

            db.DrugSuplySet.Remove(drugSuply);
            db.SaveChanges();

            return Ok(drugSuply);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DrugSuplyExists(int id)
        {
            return db.DrugSuplySet.Count(e => e.Id == id) > 0;
        }
    }
}
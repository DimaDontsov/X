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
    public class BoughtDrugSupliesController : ApiController
    {
        private XModelContainer db = new XModelContainer();

        // GET: api/BoughtDrugSuplies
        public IQueryable<BoughtDrugSuply> GetDrugSuplySet()
        {
            return db.BoughtDrugSuplySet;
        }

        // GET: api/BoughtDrugSuplies/5
        [ResponseType(typeof(BoughtDrugSuply))]
        public IHttpActionResult GetBoughtDrugSuply(int id)
        {
            BoughtDrugSuply boughtDrugSuply = db.BoughtDrugSuplySet.Find(id);
            if (boughtDrugSuply == null)
            {
                return NotFound();
            }

            return Ok(boughtDrugSuply);
        }

        // PUT: api/BoughtDrugSuplies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBoughtDrugSuply(int id, BoughtDrugSuply boughtDrugSuply)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != boughtDrugSuply.Id)
            {
                return BadRequest();
            }

            db.Entry(boughtDrugSuply).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoughtDrugSuplyExists(id))
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

        // POST: api/BoughtDrugSuplies
        [ResponseType(typeof(BoughtDrugSuply))]
        public IHttpActionResult PostBoughtDrugSuply(BoughtDrugSuply boughtDrugSuply)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DrugSuplySet.Add(boughtDrugSuply);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = boughtDrugSuply.Id }, boughtDrugSuply);
        }

        // DELETE: api/BoughtDrugSuplies/5
        [ResponseType(typeof(BoughtDrugSuply))]
        public IHttpActionResult DeleteBoughtDrugSuply(int id)
        {
            BoughtDrugSuply boughtDrugSuply = db.BoughtDrugSuplySet.Find(id);
            if (boughtDrugSuply == null)
            {
                return NotFound();
            }

            db.DrugSuplySet.Remove(boughtDrugSuply);
            db.SaveChanges();

            return Ok(boughtDrugSuply);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BoughtDrugSuplyExists(int id)
        {
            return db.DrugSuplySet.Count(e => e.Id == id) > 0;
        }
    }
}
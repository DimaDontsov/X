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
    public class DrugDistributorsController : ApiController
    {
        private XModelContainer db = new XModelContainer();

        // GET: api/DrugDistributorSet
        public IQueryable<DrugDistributor> GetDrugDistributors()
        {
            return db.DrugDistributorSet;
        }

        // GET: api/DrugDistributorSet/5
        [ResponseType(typeof(DrugDistributor))]
        public IHttpActionResult GetDrugDistributor(int id)
        {
            DrugDistributor drugDistributor = db.DrugDistributorSet.Find(id);
            if (drugDistributor == null)
            {
                return NotFound();
            }

            return Ok(drugDistributor);
        }

        // PUT: api/DrugDistributorSet/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDrugDistributor(int id, DrugDistributor drugDistributor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != drugDistributor.Id)
            {
                return BadRequest();
            }

            db.Entry(drugDistributor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrugDistributorExists(id))
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

        // POST: api/DrugDistributorSet
        [ResponseType(typeof(DrugDistributor))]
        public IHttpActionResult PostDrugDistributor(DrugDistributor drugDistributor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DrugDistributorSet.Add(drugDistributor);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = drugDistributor.Id }, drugDistributor);
        }

        // DELETE: api/DrugDistributorSet/5
        [ResponseType(typeof(DrugDistributor))]
        public IHttpActionResult DeleteDrugDistributor(int id)
        {
            DrugDistributor drugDistributor = db.DrugDistributorSet.Find(id);
            if (drugDistributor == null)
            {
                return NotFound();
            }

            db.DrugDistributorSet.Remove(drugDistributor);
            db.SaveChanges();

            return Ok(drugDistributor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DrugDistributorExists(int id)
        {
            return db.DrugDistributorSet.Count(e => e.Id == id) > 0;
        }
    }
}
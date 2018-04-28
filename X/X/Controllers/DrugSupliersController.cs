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
    public class DrugSupliersController : ApiController
    {
        private XModelContainer db = new XModelContainer();

        // GET: api/DrugSuplierSet
        public IQueryable<DrugSuplier> GetDrugSupliers()
        {
            return db.DrugSuplierSet;
        }

        // GET: api/DrugSuplierSet/5
        [ResponseType(typeof(DrugSuplier))]
        public IHttpActionResult GetDrugSuplier(int id)
        {
            DrugSuplier drugSuplier = db.DrugSuplierSet.Find(id);
            if (drugSuplier == null)
            {
                return NotFound();
            }
            /*
            foreach( var s in drugSuplier.DrugSuplies)
            {
                s.DrugSuplier = null;
            }
            */
            return Ok(drugSuplier);
        }

        // PUT: api/DrugSuplierSet/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDrugSuplier(int id, DrugSuplier drugSuplier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != drugSuplier.Id)
            {
                return BadRequest();
            }

            db.Entry(drugSuplier).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrugSuplierExists(id))
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

        // POST: api/DrugSuplierSet
        [ResponseType(typeof(DrugSuplier))]
        public IHttpActionResult PostDrugSuplier(DrugSuplier drugSuplier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DrugSuplierSet.Add(drugSuplier);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = drugSuplier.Id }, drugSuplier);
        }

        // DELETE: api/DrugSuplierSet/5
        [ResponseType(typeof(DrugSuplier))]
        public IHttpActionResult DeleteDrugSuplier(int id)
        {
            DrugSuplier drugSuplier = db.DrugSuplierSet.Find(id);
            if (drugSuplier == null)
            {
                return NotFound();
            }

            db.DrugSuplierSet.Remove(drugSuplier);
            db.SaveChanges();

            return Ok(drugSuplier);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DrugSuplierExists(int id)
        {
            return db.DrugSuplierSet.Count(e => e.Id == id) > 0;
        }
    }
}
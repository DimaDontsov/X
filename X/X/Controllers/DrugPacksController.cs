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
    public class DrugPacksController : ApiController
    {
        private XModelContainer db = new XModelContainer();

        // GET: api/DrugPacks
        public IQueryable<DrugPack> GetDrugPackSet()
        {
            return db.DrugPackSet;
        }

        // GET: api/DrugPacks/5
        [ResponseType(typeof(DrugPack))]
        public IHttpActionResult GetDrugPack(int id)
        {
            DrugPack drugPack = db.DrugPackSet.Find(id);
            if (drugPack == null)
            {
                return NotFound();
            }

            return Ok(drugPack);
        }

        // PUT: api/DrugPacks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDrugPack(int id, DrugPack drugPack)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != drugPack.Id)
            {
                return BadRequest();
            }

            db.Entry(drugPack).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrugPackExists(id))
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

        // POST: api/DrugPacks
        [ResponseType(typeof(DrugPack))]
        public IHttpActionResult PostDrugPack(DrugPack drugPack)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DrugPackSet.Add(drugPack);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = drugPack.Id }, drugPack);
        }

        // DELETE: api/DrugPacks/5
        [ResponseType(typeof(DrugPack))]
        public IHttpActionResult DeleteDrugPack(int id)
        {
            DrugPack drugPack = db.DrugPackSet.Find(id);
            if (drugPack == null)
            {
                return NotFound();
            }

            db.DrugPackSet.Remove(drugPack);
            db.SaveChanges();

            return Ok(drugPack);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DrugPackExists(int id)
        {
            return db.DrugPackSet.Count(e => e.Id == id) > 0;
        }
    }
}
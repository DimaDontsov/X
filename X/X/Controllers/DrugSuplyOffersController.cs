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
    public class DrugSuplyOffersController : ApiController
    {
        private XModelContainer db = new XModelContainer();

        // GET: api/DrugSuplyOffers
        public IQueryable<DrugSuplyOffer> GetDrugSuplies()
        {
            return db.DrugSuplies;
        }

        // GET: api/DrugSuplyOffers/5
        [ResponseType(typeof(DrugSuplyOffer))]
        public IHttpActionResult GetDrugSuplyOffer(int id)
        {
            DrugSuplyOffer drugSuplyOffer = db.DrugSuplies.Find(id);
            if (drugSuplyOffer == null)
            {
                return NotFound();
            }

            return Ok(drugSuplyOffer);
        }

        // PUT: api/DrugSuplyOffers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDrugSuplyOffer(int id, DrugSuplyOffer drugSuplyOffer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != drugSuplyOffer.Id)
            {
                return BadRequest();
            }

            var dso = db.DrugSuplyOffers.Find(id);
            dso.DrugId = drugSuplyOffer.DrugId;
            dso.UnitsOfMeasurementId = drugSuplyOffer.UnitsOfMeasurementId;
            dso.Count = drugSuplyOffer.Count;
            dso.Price = drugSuplyOffer.Price;

            db.Entry(dso).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrugSuplyOfferExists(id))
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

        // POST: api/DrugSuplyOffers
        [ResponseType(typeof(DrugSuplyOffer))]
        public IHttpActionResult PostDrugSuplyOffer(DrugSuplyOffer drugSuplyOffer)
        {
            if (!ModelState.IsValid)
            {
                //if (drugSuplyOffer.Count < 0 || drugSuplyOffer.Count <= 1000000)
                //{
                //    ModelState.AddModelError("Count", "Количество товара должно быть от 0 до 1 млн.");                   
                //}
                return BadRequest(ModelState);
            }
            drugSuplyOffer.DeliveryTime = DateTime.Now;
            db.DrugSuplies.Add(drugSuplyOffer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = drugSuplyOffer.Id }, drugSuplyOffer);
        }

        // DELETE: api/DrugSuplyOffers/5
        [ResponseType(typeof(DrugSuplyOffer))]
        public IHttpActionResult DeleteDrugSuplyOffer(int id)
        {
            DrugSuplyOffer drugSuplyOffer = db.DrugSuplies.Find(id);
            if (drugSuplyOffer == null)
            {
                return NotFound();
            }

            db.DrugSuplies.Remove(drugSuplyOffer);
            db.SaveChanges();

            return Ok(drugSuplyOffer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DrugSuplyOfferExists(int id)
        {
            return db.DrugSuplies.Count(e => e.Id == id) > 0;
        }
    }
}
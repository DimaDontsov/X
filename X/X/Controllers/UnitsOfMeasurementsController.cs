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
    public class UnitsOfMeasurementsController : ApiController
    {
        private XModelContainer db = new XModelContainer();

        // GET: api/UnitsOfMeasurements
        public IQueryable<UnitsOfMeasurement> GetUnitsOfMeasurementSet()
        {
            return db.UnitsOfMeasurementSet;
        }

        // GET: api/UnitsOfMeasurements/5
        [ResponseType(typeof(UnitsOfMeasurement))]
        public IHttpActionResult GetUnitsOfMeasurement(int id)
        {
            UnitsOfMeasurement unitsOfMeasurement = db.UnitsOfMeasurementSet.Find(id);
            if (unitsOfMeasurement == null)
            {
                return NotFound();
            }

            return Ok(unitsOfMeasurement);
        }

        // PUT: api/UnitsOfMeasurements/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUnitsOfMeasurement(int id, UnitsOfMeasurement unitsOfMeasurement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != unitsOfMeasurement.Id)
            {
                return BadRequest();
            }

            db.Entry(unitsOfMeasurement).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnitsOfMeasurementExists(id))
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

        // POST: api/UnitsOfMeasurements
        [ResponseType(typeof(UnitsOfMeasurement))]
        public IHttpActionResult PostUnitsOfMeasurement(UnitsOfMeasurement unitsOfMeasurement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UnitsOfMeasurementSet.Add(unitsOfMeasurement);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = unitsOfMeasurement.Id }, unitsOfMeasurement);
        }

        // DELETE: api/UnitsOfMeasurements/5
        [ResponseType(typeof(UnitsOfMeasurement))]
        public IHttpActionResult DeleteUnitsOfMeasurement(int id)
        {
            UnitsOfMeasurement unitsOfMeasurement = db.UnitsOfMeasurementSet.Find(id);
            if (unitsOfMeasurement == null)
            {
                return NotFound();
            }

            db.UnitsOfMeasurementSet.Remove(unitsOfMeasurement);
            db.SaveChanges();

            return Ok(unitsOfMeasurement);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UnitsOfMeasurementExists(int id)
        {
            return db.UnitsOfMeasurementSet.Count(e => e.Id == id) > 0;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

using X.Models;

namespace X.Models
{
    public partial class DrugSuply
        {
            public string SuplierName { get { return DrugSuplier.Name; } }
            public string UnitsIOfMeasurementShotrName { get { return this.UnitsIOfMeasurement.ShortName; } }
            public string DrugName { get { return Drug.Name; } }
        };
}

namespace X.Controllers
{
    

    public class DrugSupliesController : ApiController
    {
        public List<DrugSuply> GetAll() => 
            new XModelContainer().DrugSuplySet.ToList();
        
        public void Post(DrugSuply suply)
        {
            var db = new XModelContainer();
            db.DrugSuplySet.Add(suply);
            db.SaveChanges();
        }
        
        public void Delete(int suplyId)
        {
            var db = new XModelContainer();
            db.DrugSuplySet.Remove(db.DrugSuplySet.Find(suplyId));
            db.SaveChanges();

        }

        public void Put(DrugSuply suply)
        {
            var db = new XModelContainer();
            db.Entry(suply).State = EntityState.Modified;
            db.SaveChanges();

        }


    }
}

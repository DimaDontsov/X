using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using X.Models;
using Newtonsoft.Json;

namespace X.Controllers
{
    public class DistributorsController : Controller
    {
        JsonSerializerSettings jsSettings = new JsonSerializerSettings()
        {
            PreserveReferencesHandling = PreserveReferencesHandling.Objects,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };

        // GET: Distributor
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddDrugPack(DrugPack pack)
        {
            var db = new XModelContainer();
            var ds = db.BoughtDrugSuplySet.Find(pack.BoughtDrugSuplyId);
            var dp = ds.MakePack(pack.Count, pack.CoordX, pack.CoordY, pack.Price);
            db.DrugPackSet.Add(dp);
            db.Entry(ds).State = EntityState.Modified;


            db.SaveChanges();
            
            var js = JsonConvert.SerializeObject(dp, jsSettings);
            return Json(js);
        }

        [HttpPost]
        public ActionResult BuyDrugSuply(int suplyId, int distrId)
        {
            var db = new XModelContainer();
            var s = db.DrugSuplyOffers.Find(suplyId);
            var d = db.DrugDistributorSet.Find(distrId);
            var bs = d.Buy(s);
            db.DrugSuplyOffers.Remove(s);
            db.BoughtDrugSuplySet.Add(bs);
            db.Entry(d).State = EntityState.Modified;
            db.SaveChanges();
            
            var js = JsonConvert.SerializeObject(bs, jsSettings);
            return Json(js);
        }

        [HttpGet]
        public ActionResult GetPacks(int distrId)
        {
            var db = new XModelContainer();
            var d = db.DrugDistributorSet.Find(distrId);
            var packs = new List<DrugPack>();
            foreach (var pack in d.DrugPacks)
            {
                var p = (DrugPack)pack.Clone();
                packs.Add(p);
            }

            var js = JsonConvert.SerializeObject( packs, jsSettings);

            return Json(js, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetBoughtDrugSuplies(int distrId)
        {
            var db = new XModelContainer();
            var d = db.DrugDistributorSet.Find(distrId);

            var js = JsonConvert.SerializeObject(d.BoughtDrugSuplies, jsSettings);
            return Json(js, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ReturnDrugPack(int packId)
        {
            var db = new XModelContainer();
            var p = db.DrugPackSet.Find(packId);

            p.ReturnToSuply();
            var bds = p.BoughtDrugSuply; 
            db.Entry(p.BoughtDrugSuply).State = EntityState.Modified;
            db.DrugPackSet.Remove(p);
            db.SaveChanges();

            var js = JsonConvert.SerializeObject(bds, jsSettings);
            return Json(js);
        }
    }
}

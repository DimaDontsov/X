using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using X.Models;

namespace X.Controllers
{
    public class SupliersController : Controller
    {
        JsonSerializerSettings jsSettings = new JsonSerializerSettings()
        {
            PreserveReferencesHandling = PreserveReferencesHandling.Objects,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };
        // GET: Supliers
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetDrugSupliesOffers(int suplierId)
        {
            var db = new XModelContainer();
            var suplier = db.DrugSuplierSet.Find(suplierId);
            var supliesOffers = suplier.DrugSuplyOffers;

            var js = JsonConvert.SerializeObject(supliesOffers, jsSettings);
            return Json(js, JsonRequestBehavior.AllowGet);

        }
    }
}
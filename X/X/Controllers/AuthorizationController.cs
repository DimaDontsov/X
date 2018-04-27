using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using X.Models;

namespace X.Controllers
{
    public class AuthorizationController : Controller
    {

        Random random = new Random();
        // GET: Authorization
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Auth(string login, string password)
        {
            var db = new XModelContainer();
            SystemUser user = null;
            ActionResult actionResult = Redirect("/Authorization");
            var d = db.DrugDistributorSet.First();
            var distributorUser = db.DrugDistributorSet.Where((u) => u.Login == login && u.Password == password).FirstOrDefault();
            if (distributorUser != null)
            {
                user = distributorUser;
                actionResult = Redirect("/distributors/");
            } else
            {
                var suplierUser = db.DrugSuplierSet.FirstOrDefault((u) => u.Login == login && u.Password == password);
                if (suplierUser != null)
                {
                    user = suplierUser;
                    actionResult = Redirect("/supliers/");
                }
            }

            if (user != null)
            {
                TempData["LoggedUser"] = user;
                user.SessionKey = "" + random.Next();
            } else
            {
                ViewBag.ErrorMessage = "Неверный логин или пароль";
            }

            return actionResult;
        }
    }
}
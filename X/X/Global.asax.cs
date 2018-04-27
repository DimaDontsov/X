using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;

using X.Models;

namespace X
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            var db = new XModelContainer();
            var sus = db.SystemUserSet.ToList();
            var su = db.SystemUserSet.Find(1);
            var dss = db.DrugSuplierSet;
            DrugSuplier ds = dss.Find(1);
            int stop = 1;
        }
    }
}
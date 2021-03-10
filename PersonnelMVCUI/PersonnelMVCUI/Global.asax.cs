using PersonnelMVCUI.App_Start;
using PersonnelMVCUI.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PersonnelMVCUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalFilters.Filters.Add(new AuthorizeAttribute());//Authorize control at application level
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalFilters.Filters.Add(new ElmahExceptionFilter());//For logging used befaore HandleErrorAttribute().
            GlobalFilters.Filters.Add(new HandleErrorAttribute());//Handle error at application level
        }
    }
}

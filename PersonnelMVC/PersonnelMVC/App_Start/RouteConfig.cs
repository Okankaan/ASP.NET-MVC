using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PersonnelMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

           // routes.MapRoute(
           //    name: "HomePage",
           //    url: "",
           //    defaults: new { controller = "Department", action = "Hello" }//http://localhost:50176/
           //);

           // routes.MapRoute(
           //    name: "PersonnelList",
           //    url: "personnel/list/{sort}/{page}",
           //    defaults: new { controller = "Personnel", action = "PersonnelList" }//http://localhost:50176/personnel/list/salary/5
           //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonnelMVC.Controllers
{
    public class PersonnelController : Controller
    {
        // GET: Personnel
        public ActionResult Index()
        {
            return Content("Home Page of Personnel");
        }
    }
}
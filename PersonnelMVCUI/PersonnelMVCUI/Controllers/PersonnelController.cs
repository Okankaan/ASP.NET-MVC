using PersonnelMVCUI.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonnelMVCUI.Controllers
{
    public class PersonnelController : Controller
    {
        PersonnelDbEntities db = new PersonnelDbEntities();
        // GET: Personnel
        public ActionResult Index()
        {
            var model = db.Personnel.ToList();
            return View(model);
        }
    }
}
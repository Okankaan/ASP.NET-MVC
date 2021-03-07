using PersonnelMVCUI.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            var model = db.Personnel.Include(x => x.Department).ToList();//Lazy loading closed and Eager Loading using. In Eager Loading, Tables will join like this.
            return View(model);                                        //With Eager Loading(Joining), just one query goes to database.
        }
    }
}
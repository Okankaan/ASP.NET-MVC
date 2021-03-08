using PersonnelMVCUI.Models.EntityFramework;
using PersonnelMVCUI.ViewModels;
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

        public ActionResult New()
        {
            var model = new PersonnelFormViewModel()
            {
                Departments = db.Department.ToList()
            };
            return View("PersonnelForm", model);
        }

        public ActionResult Save(Personnel personnel)
        {
            if (personnel.Id == 0)//Add
            {
                db.Personnel.Add(personnel);
            }
            else//Update
            {
                db.Entry(personnel).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Update(int id)
        {
            var model = new PersonnelFormViewModel()
            {
                Departments = db.Department.ToList(),
                Personnel = db.Personnel.Find(id)
            };
            return View("PersonnelForm", model);
        }

        public ActionResult Delete(int id)
        {
            var personnelToDeleted = db.Personnel.Find(id);
            if (personnelToDeleted == null)
            {
                return HttpNotFound();
            }
            db.Personnel.Remove(personnelToDeleted);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
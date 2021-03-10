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
    [Authorize(Roles = "A,U")] //Roles A and U users can run this controller methods.
    public class PersonnelController : Controller
    {
        PersonnelDbEntities db = new PersonnelDbEntities();
        // GET: Personnel

        public ActionResult Index()
        {
            var model = db.Personnel.Include(x => x.Department).ToList();//Lazy loading closed and Eager Loading using. In Eager Loading, Tables will join like this.
            return View(model);                                        //With Eager Loading(Joining), just one query goes to database.
        }

        [Authorize(Roles = "A")]//Just roles A users can run this method.
        public ActionResult New()
        {
            var model = new PersonnelFormViewModel()
            {
                Departments = db.Department.ToList(),
                Personnel = new Personnel()
            };
            return View("PersonnelForm", model);
        }

        [ValidateAntiForgeryToken]
        public ActionResult Save(Personnel personnel)
        {
            if (!ModelState.IsValid)
            {
                var model = new PersonnelFormViewModel()
                {
                    Departments = db.Department.ToList(),
                    Personnel = personnel
                };
                return View("PersonnelForm", model);
            }
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
        public ActionResult ListPersonnels(int id)
        {
            var model = db.Personnel.Where(x => x.DepartmentId == id).ToList();
            return PartialView(model);
        }

        public ActionResult TotalSalary()
        {
            ViewBag.Salary = db.Personnel.Sum(x => x.Salary);
            return PartialView();
        }
    }
}
using PersonnelMVCUI.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonnelMVCUI.Controllers
{
    [Authorize(Roles = "A,U")]//Roles A and U users can run this controller methods.
    public class DepartmentController : Controller
    {
        PersonnelDbEntities db = new PersonnelDbEntities();
        
        public ActionResult Index()
        {
            var model = db.Department.ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult New()
        {
            return View("DepartmentForm", new Department());
        }

        //[HttpPost]
        //For using Cross Side Request Forgery(CSRF) Attacks
        [ValidateAntiForgeryToken]//running with added cookie "@Html.AntiForgeryToken()" in DepartmentForm.cshtml
        public ActionResult Save(Department department)
        {
            if (!ModelState.IsValid)
            {
                return View("DepartmentForm");
            }
            if (department.Id == 0) //For adding
            {
                db.Department.Add(department);
            }
            else
            {
                var departmentToUpdate = db.Department.Find(department.Id);
                if (departmentToUpdate == null)
                {
                    return HttpNotFound();
                }
                departmentToUpdate.Name = department.Name;
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Department");
        }

        public ActionResult Update(int id)
        {
            var model = db.Department.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View("DepartmentForm", model);
        }

        public ActionResult Delete(int id)
        {
            var departmentToDelete = db.Department.Find(id);
            if (departmentToDelete == null)
            {
                return HttpNotFound();
            }
            db.Department.Remove(departmentToDelete);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
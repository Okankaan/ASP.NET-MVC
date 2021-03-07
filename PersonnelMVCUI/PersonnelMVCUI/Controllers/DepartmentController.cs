using PersonnelMVCUI.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonnelMVCUI.Controllers
{
    public class DepartmentController : Controller
    {
        PersonnelDbEntities db = new PersonnelDbEntities();
        // GET: Department
        public ActionResult Index()
        {
            var model = db.Department.ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult New()
        {
            return View("DepartmentForm");
        }

        [HttpPost]
        public ActionResult Save(Department department)
        {
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
                else
                {
                    departmentToUpdate.Name = department.Name;
                }
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
    }
}
using PersonnelMVCUI.Models.EntityFramework;
using PersonnelMVCUI.ViewModels;
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
        //For Logging using ELMAH->http://localhost:52826/elmah.axd to log page.
        //[HandleError]// at function level. <customErrors mode="On"></customErrors> in web.config.
        public ActionResult Index()
        {
            int a = 10, b = 0;
            int c = a / b;
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
            MessageViewModel model = new MessageViewModel();
            if (department.Id == 0) //For adding
            {
                db.Department.Add(department);
                model.Message = department.Name + " successfully added...";
            }
            else
            {
                var departmentToUpdate = db.Department.Find(department.Id);
                if (departmentToUpdate == null)
                {
                    return HttpNotFound();
                }
                departmentToUpdate.Name = department.Name;
                model.Message = department.Name + " successfully updated...";
            }
            db.SaveChanges();

            model.Status = true;
            model.LinkText = "List of Departments";
            model.Url = "/Department";
            return View("_Message", model);
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
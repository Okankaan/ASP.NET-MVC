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
    }
}
using PersonnelMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonnelMVC.Controllers
{
    public class DepartmentController : Controller
    {
        public ActionResult Hello()
        {
            var department = new Department() { Id = 1, Name = "Computing" };
            return View(department);
        }

        public ActionResult Test()
        {
            return View();
        }
    }
}
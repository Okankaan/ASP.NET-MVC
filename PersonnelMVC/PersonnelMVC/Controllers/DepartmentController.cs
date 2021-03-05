using PersonnelMVC.Models;
using PersonnelMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonnelMVC.Controllers
{
    public class DepartmentController : Controller
    {
        public ActionResult Detail(int id)
        {
            var department = new Department() { Id = id, Name = "Computing" };
            var personnels = new List<Personnel>()
            {
                new Personnel(){Name="Personnel1"},
                new Personnel(){Name="Personnel2"},
                new Personnel(){Name="Personnel3"}
            };
            var model = new DepartmentDetailViewModel()
            {
                Department = department,
                Personnels = personnels
            };
            return View(model);
        }
    }
}
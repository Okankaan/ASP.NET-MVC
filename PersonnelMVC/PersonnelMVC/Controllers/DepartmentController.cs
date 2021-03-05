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
            var department = new Department() { Id = 1, Name = "Computing" };
            return RedirectToAction("Index", "Personnel", new { SortBy="salary"});
        }
        
        public ActionResult Delete(int id) // name of parameter is "id", because third parameter of url in RouteConfig.cs is "id"
        {                                            
            return Content("Coming Id: " + id);     //http://localhost:50176/department/delete/5
        }

        public ActionResult DeleteWithQueryString(int departmentId) // third parameter of url in RouteConfig.cs is "id". 
        {                                                          // So you can not send your parameter, like third parameter of url. 
            return Content("Coming Id: " + departmentId);         // http://localhost:50176/department/DeleteWithQueryString?departmentId=5
        }                                                        // Send your parameter with queryString.

        public ActionResult Update(int departmentId, string name) //This parameters are not using like this one by one, object(Department) will use instead of this parameters.
        {
            return Content("Did: " + departmentId + " " + " Name: " + name); //http://localhost:50176/department/Update?departmentId=9&name=Accounting
        }
    }
}
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

        //-Action Results-
        //Type                      -  Helper Method
        //ViewResult                -> View()            ->Return to Html
        //PartialViewResult         -> PartialView()     ->Return to Html but not having head and body tags, like table html
        //ContentResult             -> Content()         ->Return string
        //RedirectResult            -> Redirect()
        //RedirectToRouteResult     -> RedirectToAction()
        //JsonResult                -> Json()            ->Return Json result
        //File Result               -> File()            ->Return File result
        //HttpNotFoundResult        -> HttpNotFound()    ->Return Not Found result
        //HttpUnauthorizedResult    -> --------          ->Return Unauthorized result
        //EmptyResult               -> --------          ->if you don't want return any result.
    }
}
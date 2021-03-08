using PersonnelMVCUI.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PersonnelMVCUI.Controllers
{
    public class SecurityController : Controller
    {
        PersonnelDbEntities db = new PersonnelDbEntities();
        // GET: Security
        [AllowAnonymous]//All other pages except this page are blocked from unatuhorize user at the application level(Global.asax). Basicly, unauthorize user can just open this login page.
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]//All other pages except this page are blocked from unatuhorize user at the application level(Global.asax). Basicly, unauthorize user can just open this login page.
        public ActionResult Login(User user)
        {
            var userInDb = db.User.FirstOrDefault(x => x.Name == user.Name && x.Password == user.Password);
            if (userInDb != null)
            {
                FormsAuthentication.SetAuthCookie(userInDb.Name, false);//User authenticated
                return RedirectToAction("Index", "Department");
            }
            else
            {
                ViewBag.Message = "Invalid username or password...";
                return View();
            }

        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

    }
}
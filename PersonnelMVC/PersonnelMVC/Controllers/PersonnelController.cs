using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonnelMVC.Controllers
{
    public class PersonnelController : Controller
    {
        // GET: Personnel
        public ActionResult Index()
        {
            return Content("Home Page of Personnel");
        }

        [Route("personnel/list/{sort}/{page}")] //http://localhost:50176/personnel/list/salary/5
        public ActionResult PersonnelList(string sort, int page)
        {
            return Content(sort + "-" + page);
        }
    }
}
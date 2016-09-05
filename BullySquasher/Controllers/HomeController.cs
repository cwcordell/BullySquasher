using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BullySquasher.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Bully Squasher";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = new String[] { "Please let us know if you have questions or comments.",
                              "We would love to hear from you."};

            return View();
        }
    }
}
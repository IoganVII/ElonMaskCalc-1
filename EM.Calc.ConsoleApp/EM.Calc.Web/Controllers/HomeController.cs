using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EM.Calc.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About(long? id, string r)
        {
            ViewBag.Message = "Your application description page.";

            var pp = new[] { 1, 2, 3 };

            var id1 = Request.Form["id"];
            var id2 = Request.QueryString["id"];
            var id3 = Request.Cookies["id"];
            var id4 = Request.Files["id"];

            ViewBag.Вася = $"{r} => {id}";

            return View("Contact");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
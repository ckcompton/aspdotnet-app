using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPDOTNET_Web_App_1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Modifying the ViewBag.Message in the HomeController.cs";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Modifying the ViewBag.Message in the HomeController.cs";

            return View();
        }
        public ActionResult ViewPage1()
        {
            return View();
        }
        public ActionResult ViewPage2()
        {
            return View();
        }
    }
}
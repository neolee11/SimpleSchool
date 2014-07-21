using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleSchool.DataLayer;
using SimpleSchool.DataLayer.Repositories;

namespace SimpleSchool.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var repository = new CourseRepository();
            var courses = repository.GetAll();

            return View(courses);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
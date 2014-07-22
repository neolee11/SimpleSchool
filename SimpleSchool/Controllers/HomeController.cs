using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleSchool.Core.Domain;
using SimpleSchool.DataLayer;
using SimpleSchool.DataLayer.Repositories;

namespace SimpleSchool.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var repository = new CourseRepository();
            var courseId = 1;
            //var course = repository.GetGraphById(courseId);
            var courses = repository.GetGraphAll();

            var course = courses[0];
            course.Title = "History";
            course.Instructor.FirstName = "Michael";
            var student = course.Enrollments.FirstOrDefault(e => e.Student.LastName == "Smith");
            if(student != null) student.Student.FirstName = "Tom";
            repository.UpdateGraph(course);
            
            //var courses = repository.GetAllIncluding(c => c.Instructor, c => c.Enrollments.Select(e => e.Student));
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
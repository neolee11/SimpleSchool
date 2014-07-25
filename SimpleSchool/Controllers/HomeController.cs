using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            //CreateNewCourse();
            //UpdateExistingCourse();
            //CreateJustCourse();
            //DeleteCourse();
            //GetInstructor();

            var repository = new CourseRepository();
            var courses = repository.GetAll();
            //var courses = repository.GetByWhere(c => c.Credits > 4);

            return View(courses);
        }


        private void GetInstructor()
        {
            var instructorRepo = new InstructorRepository();
            var instructor = instructorRepo.GetById(2);
        }

        private void GetSomeCourse()
        {
            var courseRepo = new CourseRepository();
            var courses = courseRepo.GetByWhere(c => c.Credits > 4);
        }

        private void DeleteCourse()
        {
            var courseRepo = new CourseRepository();
            courseRepo.Delete(4);
        }

        private void CreateJustCourse()
        {
            var course = new Course();
            course.Title = "C++";
            course.Credits = 8;
            course.InstructorId = 2;

            var courseRepo = new CourseRepository();
            courseRepo.InsertOrUpdate(course);
        }

        private void CreateNewCourse()
        {
            var instructorRepo = new InstructorRepository();
            var instructor = instructorRepo.GetById(2);

            var course = new Course();
            course.Title = "English";
            course.Credits = 5;
            course.InstructorId = instructor.Id;
            //course.Instructor = instructor;
            course.Enrollments = new List<Enrollment>()
            {
                new Enrollment()
                {
                    StudentId  = 7,
                    Grade = 80
                }
            };

            var courseRepo = new CourseRepository();
            courseRepo.InsertOrUpdate(course);
        }

        private void UpdateExistingCourse()
        {
            var courseRepo = new CourseRepository();
            var course = courseRepo.GetById(4);

            course.Title = "English";
            course.Instructor.FirstName = "Kobe";

            course.Enrollments[0].Student.FirstName = "Derek";
            course.Enrollments.Add(
                new Enrollment()
                {
                    Student = new Student()
                    {
                        FirstName = "Brand",
                        LastName = "New",
                        Birthday = new DateTime(1990, 3, 2),
                        YearLevel = 10
                    },
                    Grade = 70
                });
            courseRepo.InsertOrUpdate(course);
        }

        private void UpateCourse()
        {
            var repository = new CourseRepository();
            var courseId = 1;
            //var course = repository.GetGraphById(courseId);
            var courses = repository.GetAll();

            var course = courses[0];
            course.Title = "History";
            course.Instructor.FirstName = "Michael";
            var student = course.Enrollments.FirstOrDefault(e => e.Student.LastName == "Smith");
            if (student != null) student.Student.FirstName = "Tom";
            repository.InsertOrUpdate(course);

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            var repository = new InstructorRepository();
            var instructors = repository.GetAll();

            var existingStudent = new StudentRepository().GetById(1);

            var instructor = instructors[0];
            //instructor.FirstName = "Barara";
            //instructor.TeachingCourses[0].Enrollments.Add(
            //    new Enrollment()
            //        {
            //            Student = existingStudent,
            //            Grade = 100
            //            //Course = instructor.TeachingCourses[0]
            //        }
            //    );


            instructor.TeachingCourses.RemoveAt(2);



            repository.InsertOrUpdate(instructor);

            return View(instructors);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
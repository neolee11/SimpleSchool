using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSchool.Core
{
    public abstract class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
    }

    public class Student : Person
    {
        public int YearLevel { get; set; } //1, 2, 3...12
        public virtual List<Enrollment> Enrollments { get; set; }
    }

    public class Instructor : Person
    {
        public DateTime EmploymentStartDate { get; set; }
        public virtual List<Course> TeachingCourses { get; set; }
    }

    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        public int InstructorId { get; set; }
        public virtual Instructor Instructor { get; set; }

        public virtual List<Enrollment> Enrollments { get; set; }
    }

    public class Enrollment
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

        public int CourseId { get; set; }
        public virtual Course Course { get; set; }

        public decimal Grade { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace SimpleSchool.Core.Domain
{
    public class Instructor : Person
    {
        public DateTime EmploymentStartDate { get; set; }
        public virtual List<Course> TeachingCourses { get; set; }
    }
}
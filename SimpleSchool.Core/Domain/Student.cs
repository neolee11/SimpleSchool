using System.Collections.Generic;

namespace SimpleSchool.Core.Domain
{
    public class Student : Person
    {
        public int YearLevel { get; set; } //1, 2, 3...12
        public virtual List<Enrollment> Enrollments { get; set; }
    }
}

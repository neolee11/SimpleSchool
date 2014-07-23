using System.Collections.Generic;

namespace SimpleSchool.Core.Domain
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        public int InstructorId { get; set; }
        public virtual Instructor Instructor { get; set; }

        public virtual List<Enrollment> Enrollments { get; set; }

    }
}
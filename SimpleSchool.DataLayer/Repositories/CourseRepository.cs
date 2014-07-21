using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SimpleSchool.Core.Domain;
using SimpleSchool.Core.RepositoryInterfaces;

namespace SimpleSchool.DataLayer.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        public List<Course> GetAll()
        {
            using (var ctx = new SchoolModelContext())
            {
                return ctx.Courses.Include(c => c.Instructor)
                    .Include(c => c.Enrollments.Select(e => e.Student)).
                    ToList();
            }
        }

        public Course GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(Course t)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Course t)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using RefactorThis.GraphDiff;
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
                 return ctx.Courses.ToList();
             }
        }

        public Course GetById(int id)
        {
            using (var ctx = new SchoolModelContext())
            {
                return ctx.Courses.SingleOrDefault(c => c.Id == id);
            }
        }

        public void InsertOrUpdate(Course t)
        {
            using (var ctx = new SchoolModelContext())
            {
                ctx.Entry(t).State = t.Id == 0 ? EntityState.Added : EntityState.Modified;
                ctx.SaveChanges();
            }
        }

        public List<Course> GetGraphAll()
        {
            using (var ctx = new SchoolModelContext())
            {
                return ctx.Courses
                    .Include(c => c.Instructor)
                    .Include(c => c.Enrollments.Select(e => e.Student))
                    .ToList();
            }
        }

        public List<Course> GetAllIncluding(params System.Linq.Expressions.Expression<System.Func<Course, object>>[] includeProperties)
        {
            using (var ctx = new SchoolModelContext())
            {
                IQueryable<Course> query = ctx.Courses;
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
                return query.ToList();
            }
        }

        public Course GetGraphById(int id)
        {
            using (var ctx = new SchoolModelContext())
            {
                return ctx.Courses.Where(c => c.Id == id)
                    .Include(c => c.Instructor)
                    .Include(c => c.Enrollments.Select(e => e.Student))
                    .SingleOrDefault();
            }
        }

        public void InsertGraph(Course t)
        {
            //Insert : use foreign key property for related objects to avoid insert an existing object
            using (var ctx = new SchoolModelContext())
            {
                ctx.Courses.Add(t); //everything in the graph will be marked added except the one using foreigh key
            }
        }

        public void UpdateGraph(Course t)
        {
            using (var ctx = new SchoolModelContext())
            {
                ctx.UpdateGraph(t,
                    map =>
                        map.OwnedEntity(c => c.Instructor)
                            .OwnedCollection(c => c.Enrollments, with => with.OwnedEntity(s => s.Student))
                    );

                ctx.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var ctx = new SchoolModelContext())
            {
                var entityToDelete = ctx.Courses.FirstOrDefault(c => c.Id == id);
                ctx.Courses.Remove(entityToDelete);
                ctx.SaveChanges();
            }
        }





       
    }
}
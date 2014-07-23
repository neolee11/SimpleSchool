using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using RefactorThis.GraphDiff;
using SimpleSchool.Core.Domain;
using SimpleSchool.Core.RepositoryInterfaces;
using System.Collections.Generic;

namespace SimpleSchool.DataLayer.Repositories
{
    public class InstructorRepository : IInstructorRepository
    {
        public List<Instructor> GetAll()
        {
            using (var ctx = new SchoolModelContext())
            {
                return ctx.Instructors
                    .Include(i => i.TeachingCourses.Select(c => c.Enrollments.Select(e => e.Student)))
                    .Include(i => i.TeachingCourses.Select(c => c.Enrollments.Select(e => e.Course)))
                    .ToList();
            }
        }

        public List<Instructor> GetAllIncluding(params Expression<Func<Instructor, object>>[] includeProperties)
        {
            using (var ctx = new SchoolModelContext())
            {
                IQueryable<Instructor> query = ctx.Instructors;
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
                return query.ToList();
            }
        }

        public List<Instructor> GetByWhere(Expression<Func<Instructor, bool>> filter)
        {
            using (var ctx = new SchoolModelContext())
            {
                return ctx.Instructors.Where(filter)
                    .Include(i => i.TeachingCourses.Select(c => c.Enrollments.Select(e => e.Student)))
                    .Include(i => i.TeachingCourses.Select(c => c.Enrollments.Select(e => e.Course)))
                    .ToList();
            }
        }

        public Instructor GetById(int id)
        {
            using (var ctx = new SchoolModelContext())
            {
                return ctx.Instructors.Where(i => i.Id == id)
                    .Include(i => i.TeachingCourses.Select(c => c.Enrollments.Select(e => e.Student)))
                    .Include(i => i.TeachingCourses.Select(c => c.Enrollments.Select(e => e.Course)))
                    .SingleOrDefault();
            }
        }

        public void InsertOrUpdate(Instructor t)
        {
            using (var ctx = new SchoolModelContext())
            {
                ctx.UpdateGraph(t,
                    map =>
                        map.OwnedCollection(i => i.TeachingCourses,
                            with1 =>
                                with1.OwnedCollection(o => o.Enrollments,
                                    with2 => with2.OwnedEntity(e => e.Student).OwnedEntity(e => e.Course)))

                    );
            }
        }

        public void Delete(int id)
        {
            using (var ctx = new SchoolModelContext())
            {
                var entityToDelete = ctx.Instructors.FirstOrDefault(i => i.Id == id);
                ctx.Instructors.Remove(entityToDelete);
                ctx.SaveChanges();
            }
        }
    }
}
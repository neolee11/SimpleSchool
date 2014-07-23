using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using RefactorThis.GraphDiff;
using SimpleSchool.Core.Domain;
using SimpleSchool.Core.RepositoryInterfaces;

namespace SimpleSchool.DataLayer.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        public List<Student> GetAll()
        {
            using (var ctx = new SchoolModelContext())
            {
                return ctx.Students
                    .Include(s => s.Enrollments.Select(e => e.Course.Instructor))
                    .ToList();
            }
        }

        public List<Student> GetAllIncluding(params Expression<Func<Student, object>>[] includeProperties)
        {
            using (var ctx = new SchoolModelContext())
            {
                IQueryable<Student> query = ctx.Students;
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
                return query.ToList();
            }
        }

        public List<Student> GetByWhere(Expression<Func<Student, bool>> filter)
        {
            using (var ctx = new SchoolModelContext())
            {
                return ctx.Students.Where(filter)
                    .Include(s => s.Enrollments.Select(e => e.Course.Instructor))
                    .ToList();
            }
        }

        public Student GetById(int id)
        {
            using (var ctx = new SchoolModelContext())
            {
                return ctx.Students.Where(s => s.Id == id)
                    .Include(s => s.Enrollments.Select(e => e.Course.Instructor))
                    .SingleOrDefault();
            }
        }

        public void InsertOrUpdate(Student t)
        {
            using (var ctx = new SchoolModelContext())
            {
                ctx.UpdateGraph(t,
                    map =>
                        map.OwnedCollection(s => s.Enrollments, 
                        with => with.OwnedEntity(c => c.Course, with2 => with2.OwnedEntity(i => i.Instructor)))
                    );

                ctx.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var ctx = new SchoolModelContext())
            {
                var entityToDelete = ctx.Students.FirstOrDefault(c => c.Id == id);
                ctx.Students.Remove(entityToDelete);
                ctx.SaveChanges();
            }
        }
    }
}
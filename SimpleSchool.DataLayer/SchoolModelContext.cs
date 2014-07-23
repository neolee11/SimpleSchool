using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleSchool.Core;
using SimpleSchool.Core.Domain;
using SimpleSchool.DataLayer.Migrations;

namespace SimpleSchool.DataLayer
{
    public class SchoolModelContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }

        public SchoolModelContext()
            : base("SimpleSchoolConnStr")
        {
            //Database.SetInitializer(new CustomDropCreateDatabaseIfModelChanges());
            //Database.SetInitializer(new DropCreateDatabaseAlways<SchoolModelContext>()); 
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<SchoolModelContext, Configuration>()); //Better to do in the app/web.config files 
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //modelBuilder.Configurations.Add(new InstructorMapping());
            modelBuilder.Configurations.Add(new PersonMapping());

            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Instructor>().ToTable("Instructor");

            base.OnModelCreating(modelBuilder);
        }
    }

    public class PersonMapping : EntityTypeConfiguration<Person>
    {
        public PersonMapping()
        {
            this.Property(p => p.FirstName).HasMaxLength(50);
            this.Property(p => p.LastName).HasMaxLength(50);

            this.Ignore(p => p.FullName);
        }
    }
    //public class InstructorMapping : EntityTypeConfiguration<Instructor>
    //{
    //    public InstructorMapping()
    //    {
    //        this.HasKey(i => i.Id);
    //        this.HasMany(i => i.TeachingCourses).WithRequired(c => c.Instructor);

    //    }
    //}

    //public class CourseMapping : EntityTypeConfiguration<Course>
    //{
    //    public CourseMapping()
    //    {
    //        this.HasKey(c => c.Id);
    //    }
    //}

    public static class ContextHelper
    {
        public static void ApplyStateChanges(this DbContext context)
        {
            foreach (var entry in context.ChangeTracker.Entries<IObjectWithEntityState>())
            {
                IObjectWithEntityState stateInfo = entry.Entity;
                entry.State = ObjectEntityStateHelper.ConvertState(stateInfo.EntityState);

                
            }
        }
    }

    public class ObjectEntityStateHelper
    {
        public static EntityState ConvertState(ObjectEntityState state)
        {
            switch (state)
            {
                case ObjectEntityState.Added:
                    return EntityState.Added;
                case ObjectEntityState.Modified:
                    return EntityState.Modified;
                case ObjectEntityState.Deleted:
                    return EntityState.Deleted;
                default:
                    return EntityState.Unchanged;
            }
        }
    }
}

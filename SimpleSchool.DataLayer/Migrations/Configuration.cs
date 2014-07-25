using System.Collections.Generic;
using SimpleSchool.Core.Domain;

namespace SimpleSchool.DataLayer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SimpleSchool.DataLayer.SchoolModelContext>
    {
        public Configuration()
        {
            //AutomaticMigrationsEnabled = false;
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "SimpleSchool.DataLayer.SchoolModelContext";
        }

        protected override void Seed(SimpleSchool.DataLayer.SchoolModelContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //context.Students.AddOrUpdate(
            //    s => s.LastName,
            //    new Student
            //    {
            //        FirstName = "Daniel",
            //        LastName = "Smith",
            //        YearLevel = 8,
            //        Birthday = 

            //        Enrollments = new List<Enrollment>()
            //                {
            //                    new Enrollment()
            //                    {
            //                        Course = new Course()
            //                        {
            //                            Title = "History",
            //                            Credits = 4,
            //                            Instructor = new Instructor()
            //                            {
            //                                FirstName = "Michael",
            //                                LastName = "Jordon",
            //                                EmploymentStartDate = new DateTime(2010, 3, 1)
            //                            }
            //                        },
            //                        Grade = 90
            //                    }
            //                }
            //    }

            //    );
        }
     
    }
}

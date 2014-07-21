using System;
using System.Collections.Generic;
using System.Data.Entity;
using SimpleSchool.Core;

namespace SimpleSchool.DataLayer
{
    public class CustomDropCreateDatabaseIfModelChanges : DropCreateDatabaseIfModelChanges<SchoolModelContext>
    {
        protected override void Seed(SchoolModelContext context)
        {
            var student = new Student
            {
                FirstName = "Daniel",
                LastName = "Smith",
                YearLevel = 8,

                Enrollments = new List<Enrollment>()
                {
                    new Enrollment()
                    {
                        Course = new Course()
                        {
                            Title = "History",
                            Credits = 4,
                            Instructor = new Instructor()
                            {
                                FirstName = "Michael",
                                LastName = "Jordon",
                                EmploymentStartDate = new DateTime(2010, 3, 1)
                            }
                        },
                        Grade = 90
                    }
                }

            };

            context.Students.Add(student);

            base.Seed(context);
        }
    }
}
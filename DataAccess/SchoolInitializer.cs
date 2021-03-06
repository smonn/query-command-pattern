﻿using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using SampleEntityFramework.PersistenceModels;

namespace SampleEntityFramework.DataAccess
{
    public class SchoolInitializer : DropCreateDatabaseIfModelChanges<SchoolContext>
    {
        protected override void Seed(SchoolContext context)
        {
            AddStudents(context);
            AddCourses(context);
            AddEnrollments(context);
        }

        private static void AddEnrollments(ISchoolContext context)
        {
            var enrollments = new []
            {
                new Enrollment
                {
                    StudentId = 1,
                    CourseId = 1,
                    GradeValue = 1,
                },
                new Enrollment
                {
                    StudentId = 1,
                    CourseId = 2,
                    GradeValue = 3,
                },
                new Enrollment
                {
                    StudentId = 1,
                    CourseId = 3,
                    GradeValue = 2,
                },
                new Enrollment
                {
                    StudentId = 2,
                    CourseId = 4,
                    GradeValue = 2,
                },
                new Enrollment
                {
                    StudentId = 2,
                    CourseId = 5,
                    GradeValue = 5,
                },
                new Enrollment
                {
                    StudentId = 2,
                    CourseId = 6,
                    GradeValue = 5,
                },
                new Enrollment
                {
                    StudentId = 3,
                    CourseId = 1,
                    GradeValue = 0,
                },
                new Enrollment
                {
                    StudentId = 4,
                    CourseId = 1,
                    GradeValue = 0,
                },
                new Enrollment
                {
                    StudentId = 4,
                    CourseId = 2,
                    GradeValue = 5,
                },
                new Enrollment
                {
                    StudentId = 5,
                    CourseId = 3,
                    GradeValue = 3,
                },
                new Enrollment
                {
                    StudentId = 6,
                    CourseId = 4,
                    GradeValue = 0,
                },
                new Enrollment
                {
                    StudentId = 7,
                    CourseId = 5,
                    GradeValue = 1,
                },
            };

            context.Enrollments.AddOrUpdate(enrollments);
            context.Commit();
        }

        private static void AddCourses(ISchoolContext context)
        {
            var courses = new []
            {
                new Course
                {
                    CourseCode = 1050,
                    Title = "Chemistry",
                    Credits = 3,
                },
                new Course
                {
                    CourseCode = 4022,
                    Title = "Microeconomics",
                    Credits = 3,
                },
                new Course
                {
                    CourseCode = 4041,
                    Title = "Macroeconomics",
                    Credits = 3,
                },
                new Course
                {
                    CourseCode = 1045,
                    Title = "Calculus",
                    Credits = 4,
                },
                new Course
                {
                    CourseCode = 3141,
                    Title = "Trigonometry",
                    Credits = 4,
                },
                new Course
                {
                    CourseCode = 2021,
                    Title = "Composition",
                    Credits = 3,
                },
                new Course
                {
                    CourseCode = 2042,
                    Title = "Literature",
                    Credits = 4,
                }
            };

            context.Courses.AddOrUpdate(courses);
            context.Commit();
        }

        private static void AddStudents(ISchoolContext context)
        {
            var students = new []
            {
                new Student
                {
                    FirstName = "Carson",
                    LastName = "Alexander",
                    EnrollmentDate = DateTime.Parse("2005-09-01"),
                },
                new Student
                {
                    FirstName = "Meredith",
                    LastName = "Alonso",
                    EnrollmentDate = DateTime.Parse("2002-09-01"),
                },
                new Student
                {
                    FirstName = "Arturo",
                    LastName = "Anand",
                    EnrollmentDate = DateTime.Parse("2003-09-01"),
                },
                new Student
                {
                    FirstName = "Gytis",
                    LastName = "Barzdukas",
                    EnrollmentDate = DateTime.Parse("2002-09-01"),
                },
                new Student
                {
                    FirstName = "Yan",
                    LastName = "Li",
                    EnrollmentDate = DateTime.Parse("2002-09-01"),
                },
                new Student
                {
                    FirstName = "Peggy",
                    LastName = "Justice",
                    EnrollmentDate = DateTime.Parse("2001-09-01"),
                },
                new Student
                {
                    FirstName = "Laura",
                    LastName = "Norman",
                    EnrollmentDate = DateTime.Parse("2003-09-01"),
                },
                new Student
                {
                    FirstName = "Nino",
                    LastName = "Olivetto",
                    EnrollmentDate = DateTime.Parse("2005-09-01"),
                },
            };

            context.Students.AddOrUpdate(students);
            context.Commit();
        }
    }
}
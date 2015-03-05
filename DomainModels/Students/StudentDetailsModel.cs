using System;
using System.Collections.Generic;
using SampleEntityFramework.DomainModels.Courses;

namespace SampleEntityFramework.DomainModels.Students
{
    public class StudentDetailsModel
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public IEnumerable<CourseEnrollmentListModel> Courses { get; set; }

        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalCourses { get; set; }
    }
}
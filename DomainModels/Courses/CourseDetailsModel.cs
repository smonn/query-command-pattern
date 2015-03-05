using System.Collections.Generic;
using SampleEntityFramework.DomainModels.Students;

namespace SampleEntityFramework.DomainModels.Courses
{
    public class CourseDetailsModel
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public IEnumerable<StudentEnrollmentListModel> Students { get; set; }

        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalStudents { get; set; }
    }
}
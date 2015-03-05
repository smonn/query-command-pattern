using System.Collections.Generic;

namespace SampleEntityFramework.DomainModels.Courses
{
    public class CoursesModel
    {
        public IEnumerable<CourseListModel> Courses { get; set; }

        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalCourses { get; set; }
    }
}
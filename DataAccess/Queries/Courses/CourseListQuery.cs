using System.Linq;
using SampleEntityFramework.DomainModels.Courses;

namespace SampleEntityFramework.DataAccess.Queries.Courses
{
    public class CourseListQuery : IQuery<CoursesModel>
    {
        public int? Page { get; set; }
        public int? PageSize { get; set; }

        public CoursesModel Execute(ISchoolContext context)
        {
            var courses = context.Courses
                .OrderBy(c => c.Title)
                .Select(c => new CourseListModel
                {
                    CourseId = c.CourseId,
                    CourseCode = c.CourseCode,
                    Credits = c.Credits,
                    EnrollmentCount = c.Enrollments.Count,
                    Title = c.Title
                });

            return new CoursesModel(courses, Page, PageSize);
        }
    }
}
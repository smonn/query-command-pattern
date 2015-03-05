using System.Linq;
using SampleEntityFramework.DomainModels.Courses;
using SampleEntityFramework.PersistenceModels;

namespace SampleEntityFramework.DataAccess.Queries.Courses
{
    public class CourseListQuery : IQuery<CoursesModel>
    {
        public const int DefaultPageSize = 2;
        private const int MinPageSize = 1;
        private const int MaxPageSize = 100;

        public int? Page { get; set; }
        public int? PageSize { get; set; }

        public CoursesModel Execute(ISchoolContext context)
        {
            var result = new CoursesModel();

            IQueryable<Course> courses = context.Courses.OrderBy(c => c.Title);

            var pageSize = PageSize ?? DefaultPageSize;
            if (pageSize < MinPageSize) pageSize = MinPageSize;
            else if (pageSize > MaxPageSize) pageSize = MaxPageSize;

            result.TotalCourses = courses.Count();
            result.CurrentPage = Page.HasValue && Page > 1 ? Page.Value : 1;
            result.PageSize = pageSize;

            if (result.CurrentPage > 1)
            {
                var skip = (result.CurrentPage - 1) * pageSize;
                courses = courses.Skip(skip);
            }

            courses = courses.Take(pageSize);
            result.Courses = courses.Select(
                c => new CourseListModel
                {
                    CourseId = c.CourseId,
                    Credits = c.Credits,
                    EnrollmentCount = c.Enrollments.Count(),
                    Title = c.Title
                });

            return result;
        }
    }
}
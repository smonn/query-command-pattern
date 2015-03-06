using System.Linq;
using SampleEntityFramework.DomainModels.Common;
using SampleEntityFramework.DomainModels.Courses;
using SampleEntityFramework.PersistenceModels;

namespace SampleEntityFramework.DataAccess.Queries.Courses
{
    public class CourseListQuery : IQuery<CoursesModel>
    {
        public int? Page { get; set; }
        public int? PageSize { get; set; }

        public CoursesModel Execute(ISchoolContext context)
        {
            var result = new CoursesModel();

            IQueryable<Course> courses = context.Courses.OrderBy(c => c.Title);

            result.Pagination = PaginationModel.Create(courses.Count(), Page, PageSize);
            if (result.Pagination.ShouldSkip)
                courses = courses.Skip(result.Pagination.SkipAmount);
            courses = courses.Take(result.Pagination.PageSize);

            result.Courses = courses.Select(
                c => new CourseListModel
                {
                    CourseId = c.CourseId,
                    Credits = c.Credits,
                    EnrollmentCount = c.Enrollments.Count(),
                    Title = c.Title
                })
                .ToList();

            return result;
        }
    }
}
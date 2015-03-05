using System.Linq;
using SampleEntityFramework.DomainModels.Courses;
using SampleEntityFramework.DomainModels.Students;
using SampleEntityFramework.PersistenceModels;

namespace SampleEntityFramework.DataAccess.Queries.Courses
{
    public class CourseDetailsQuery : IQuery<CourseDetailsModel>
    {
        public const int DefaultPageSize = 2;
        private const int MinPageSize = 1;
        private const int MaxPageSize = 100;

        public int Id { get; set; }

        public int? Page { get; set; }
        public int? PageSize { get; set; }

        public CourseDetailsModel Execute(ISchoolContext context)
        {
            var course = context.Courses
                .Where(c => c.CourseId == Id)
                .Select(c => new CourseDetailsModel
                {
                    CourseId = c.CourseId,
                    Credits = c.Credits,
                    Title = c.Title,
                })
                .FirstOrDefault();

            if (course == null) return null;

            IQueryable<Enrollment> enrollments = context.Enrollments
                .Where(e => e.CourseId == Id)
                .OrderBy(e => e.Student.LastName)
                .ThenBy(e => e.Student.FirstName);

            var pageSize = PageSize ?? DefaultPageSize;
            if (pageSize < MinPageSize) pageSize = MinPageSize;
            else if (pageSize > MaxPageSize) pageSize = MaxPageSize;

            course.TotalStudents = enrollments.Count();
            course.CurrentPage = Page.HasValue && Page > 1 ? Page.Value : 1;
            course.PageSize = pageSize;

            if (course.CurrentPage > 1)
            {
                var skip = (course.CurrentPage - 1) * pageSize;
                enrollments = enrollments.Skip(skip);
            }

            enrollments = enrollments.Take(pageSize);

            course.Students = enrollments
                .Select(e => new StudentEnrollmentListModel
                {
                    FirstName = e.Student.FirstName,
                    Grade = e.Grade,
                    LastName = e.Student.LastName,
                    StudentId = e.StudentId,
                });

            return course;
        }
    }
}
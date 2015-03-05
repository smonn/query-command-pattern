using System.Linq;
using SampleEntityFramework.DomainModels.Courses;
using SampleEntityFramework.DomainModels.Students;
using SampleEntityFramework.PersistenceModels;

namespace SampleEntityFramework.DataAccess.Queries.Students
{
    public class StudentDetailsQuery : IQuery<StudentDetailsModel>
    {
        public const int DefaultPageSize = 2;
        private const int MinPageSize = 1;
        private const int MaxPageSize = 100;

        public int Id { get; set; }

        public int? Page { get; set; }
        public int? PageSize { get; set; }

        public StudentDetailsModel Execute(ISchoolContext context)
        {
            var student = context.Students
                .Where(s => s.StudentId == Id)
                .Select(s => new StudentDetailsModel
                {
                    EnrollmentDate = s.EnrollmentDate,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    StudentId = s.StudentId,
                })
                .FirstOrDefault();

            if (student == null) return null;

            IQueryable<Enrollment> enrollments = context.Enrollments
                .Where(e => e.StudentId == Id)
                .OrderBy(e => e.Course.Title);

            var pageSize = PageSize ?? DefaultPageSize;
            if (pageSize < MinPageSize) pageSize = MinPageSize;
            else if (pageSize > MaxPageSize) pageSize = MaxPageSize;

            student.TotalCourses = enrollments.Count();
            student.CurrentPage = Page.HasValue && Page > 1 ? Page.Value : 1;
            student.PageSize = pageSize;

            if (student.CurrentPage > 1)
            {
                var skip = (student.CurrentPage - 1) * pageSize;
                enrollments = enrollments.Skip(skip);
            }

            enrollments = enrollments.Take(pageSize);

            student.Courses = enrollments
                .Select(e => new CourseEnrollmentListModel
                {
                    CourseId = e.CourseId,
                    Credits = e.Course.Credits,
                    Title = e.Course.Title,
                    Grade = e.Grade,
                });

            return student;
        }
    }
}
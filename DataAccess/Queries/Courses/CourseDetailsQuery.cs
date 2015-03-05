using System.Linq;
using SampleEntityFramework.DomainModels.Common;
using SampleEntityFramework.DomainModels.Courses;
using SampleEntityFramework.DomainModels.Students;
using SampleEntityFramework.PersistenceModels;

namespace SampleEntityFramework.DataAccess.Queries.Courses
{
    public class CourseDetailsQuery : IQuery<CourseDetailsModel>
    {
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

            course.Pagination = PaginationModel.Create(enrollments.Count(), Page, PageSize);
            if (course.Pagination.ShouldSkip)
                enrollments = enrollments.Skip(course.Pagination.SkipAmount);
            enrollments = enrollments.Take(course.Pagination.PageSize);

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
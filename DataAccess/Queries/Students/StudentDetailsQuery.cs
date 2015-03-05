using System.Linq;
using SampleEntityFramework.DomainModels.Common;
using SampleEntityFramework.DomainModels.Courses;
using SampleEntityFramework.DomainModels.Students;
using SampleEntityFramework.PersistenceModels;

namespace SampleEntityFramework.DataAccess.Queries.Students
{
    public class StudentDetailsQuery : IQuery<StudentDetailsModel>
    {
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

            student.Pagination = PaginationModel.Create(enrollments.Count(), Page, PageSize);
            if (student.Pagination.ShouldSkip)
                enrollments = enrollments.Skip(student.Pagination.SkipAmount);
            enrollments = enrollments.Take(student.Pagination.PageSize);

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
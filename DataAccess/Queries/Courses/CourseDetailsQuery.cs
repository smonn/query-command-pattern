using System.Linq;
using SampleEntityFramework.DomainModels.Courses;
using SampleEntityFramework.DomainModels.Students;

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
                .Where(c => c.CourseCode == Id)
                .Select(c => new CourseDetailsModel
                {
                    Details = new CourseListModel
                    {
                        EnrollmentCount = c.Enrollments.Count,
                        CourseId = c.CourseId,
                        CourseCode = c.CourseCode,
                        Credits = c.Credits,
                        Title = c.Title,
                    }
                })
                .FirstOrDefault();

            if (course == null) return null;

            var enrollments = context.Enrollments
                .Where(e => e.CourseId == course.Details.CourseId)
                .OrderBy(e => e.Student.LastName)
                .ThenBy(e => e.Student.FirstName)
                .Select(e => new StudentEnrollmentListModel
                {
                    FirstName = e.Student.FirstName,
                    GradeValue = e.GradeValue,
                    LastName = e.Student.LastName,
                    EnrollmentDate = e.Student.EnrollmentDate,
                    StudentId = e.StudentId,
                });

            return course.AddEnrollments(enrollments, Page, PageSize);
        }
    }
}
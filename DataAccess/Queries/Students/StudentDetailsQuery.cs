using System.Linq;
using SampleEntityFramework.DomainModels.Courses;
using SampleEntityFramework.DomainModels.Students;

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
                    Details = new StudentListModel
                    {
                        EnrollmentDate = s.EnrollmentDate,
                        FirstName = s.FirstName,
                        LastName = s.LastName,
                        StudentId = s.StudentId,
                    }
                })
                .FirstOrDefault();

            if (student == null) return null;

            var enrollments = context.Enrollments
                .Where(e => e.StudentId == Id)
                .OrderBy(e => e.Course.Title)
                .Select(e => new CourseEnrollmentListModel
                {
                    CourseId = e.CourseId,
                    CourseCode = e.Course.CourseCode,
                    Credits = e.Course.Credits,
                    Title = e.Course.Title,
                    GradeValue = e.GradeValue,
                });

            return student.AddEnrollments(enrollments, Page, PageSize);
        }
    }
}
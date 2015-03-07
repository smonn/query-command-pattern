using System.Linq;
using SampleEntityFramework.DomainModels.Students;

namespace SampleEntityFramework.DataAccess.Queries.Students
{
    public class StudentListQuery : IQuery<StudentsModel>
    {
        public int? Page { get; set; }
        public int? PageSize { get; set; }

        public StudentsModel Execute(ISchoolContext context)
        {
            var students = context.Students
                .OrderBy(c => c.LastName)
                .ThenBy(c => c.FirstName)
                .Select(s => new StudentListModel
                {
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    StudentId = s.StudentId,
                    EnrollmentDate = s.EnrollmentDate,
                    EnrollmentCount = s.Enrollments.Count,
                });

            return new StudentsModel(students, Page, PageSize);
        }
    }
}
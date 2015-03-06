using System.Linq;
using SampleEntityFramework.DomainModels.Common;
using SampleEntityFramework.DomainModels.Students;
using SampleEntityFramework.PersistenceModels;

namespace SampleEntityFramework.DataAccess.Queries.Students
{
    public class StudentListQuery : IQuery<StudentsModel>
    {
        public int? Page { get; set; }
        public int? PageSize { get; set; }

        public StudentsModel Execute(ISchoolContext context)
        {
            var result = new StudentsModel();

            IQueryable<Student> students = context.Students
                .OrderBy(c => c.LastName)
                .ThenBy(c => c.FirstName);

            result.Pagination = PaginationModel.Create(students.Count(), Page, PageSize);
            if (result.Pagination.ShouldSkip)
                students = students.Skip(result.Pagination.SkipAmount);
            students = students.Take(result.Pagination.PageSize);

            result.Students = students.Select(
                s => new StudentListModel
                {
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    StudentId = s.StudentId,
                    EnrollmentDate = s.EnrollmentDate,
                    EnrollmentCount = s.Enrollments.Count(),
                })
                .ToList();

            return result;
        }
    }
}
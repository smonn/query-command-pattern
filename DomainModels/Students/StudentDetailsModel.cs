using System.Linq;
using SampleEntityFramework.DomainModels.Common;
using SampleEntityFramework.DomainModels.Courses;

namespace SampleEntityFramework.DomainModels.Students
{
    public class StudentDetailsModel : PaginatedModel<CourseEnrollmentListModel>
    {
        public StudentListModel Details { get; set; }

        public StudentDetailsModel AddEnrollments(IQueryable<CourseEnrollmentListModel> enrollments, int? page, int? pageSize)
        {
            ApplyPaging(enrollments, page, pageSize);
            return this;
        }
    }
}
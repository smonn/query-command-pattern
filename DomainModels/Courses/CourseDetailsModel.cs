using System.Linq;
using SampleEntityFramework.DomainModels.Common;
using SampleEntityFramework.DomainModels.Students;

namespace SampleEntityFramework.DomainModels.Courses
{
    public class CourseDetailsModel : PaginatedModel<StudentEnrollmentListModel>
    {
        public CourseListModel Details { get; set; }

        public CourseDetailsModel AddEnrollments(IQueryable<StudentEnrollmentListModel> enrollments, int? page, int? pageSize)
        {
            ApplyPaging(enrollments, page, pageSize);
            return this;
        }
    }
}

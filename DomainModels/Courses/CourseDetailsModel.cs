using System.Collections.Generic;
using SampleEntityFramework.DomainModels.Common;
using SampleEntityFramework.DomainModels.Students;

namespace SampleEntityFramework.DomainModels.Courses
{
    public class CourseDetailsModel : CourseListModel
    {
        public IEnumerable<StudentEnrollmentListModel> Students { get; set; }

        public PaginationModel Pagination { get; set; }
    }
}
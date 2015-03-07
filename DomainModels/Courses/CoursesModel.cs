using System.Linq;
using SampleEntityFramework.DomainModels.Common;

namespace SampleEntityFramework.DomainModels.Courses
{
    public class CoursesModel : PaginatedModel<CourseListModel>
    {
        public CoursesModel(IQueryable<CourseListModel> data, int? page, int? pageSize) : base(data, page, pageSize) { }
    }
}
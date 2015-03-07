using System.Linq;
using SampleEntityFramework.DomainModels.Common;

namespace SampleEntityFramework.DomainModels.Students
{
    public class StudentsModel : PaginatedModel<StudentListModel>
    {
        public StudentsModel(IQueryable<StudentListModel> data, int? page, int? pageSize) : base(data, page, pageSize) { }
    }
}
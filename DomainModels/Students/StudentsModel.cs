using System.Collections.Generic;
using SampleEntityFramework.DomainModels.Common;

namespace SampleEntityFramework.DomainModels.Students
{
    public class StudentsModel
    {
        public IEnumerable<StudentListModel> Students { get; set; }

        public PaginationModel Pagination { get; set; }
    }
}
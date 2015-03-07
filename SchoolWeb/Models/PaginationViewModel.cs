using SampleEntityFramework.DomainModels.Common;

namespace SampleEntityFramework.SchoolWeb.Models
{
    public class PaginationViewModel<TModel>
    {
        public PaginatedModel<TModel> Data { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public string Area { get; set; }
    }
}
using SampleEntityFramework.DomainModels.Common;

namespace SampleEntityFramework.SchoolWeb.Models
{
    public class PaginationViewModel
    {
        public PaginationModel Data { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public string Area { get; set; }
    }
}
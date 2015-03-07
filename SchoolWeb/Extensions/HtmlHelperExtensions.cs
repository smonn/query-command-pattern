using System.Web.Mvc;
using System.Web.Mvc.Html;
using SampleEntityFramework.DomainModels.Common;
using SampleEntityFramework.SchoolWeb.Models;

namespace SampleEntityFramework.SchoolWeb.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString Pagination<TModel>(this HtmlHelper html, PaginatedModel<TModel> model, string action,
            string controller, string area = null)
        {
            return html.Partial("_Pagination", new PaginationViewModel<TModel>
            {
                Action = action,
                Area = area,
                Controller = controller,
                Data = model,
            });
        }
    }
}
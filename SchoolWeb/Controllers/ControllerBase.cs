using System.Web.Mvc;

namespace SampleEntityFramework.SchoolWeb.Controllers
{
    public class ControllerBase : Controller
    {
        protected ViewResult ViewIfNotNull(object model)
        {
            return model == null
                ? View("NotFound")
                : View(model);
        }
    }
}
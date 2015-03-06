using System.Web.Mvc;

namespace SampleEntityFramework.SchoolWeb.Controllers
{
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}
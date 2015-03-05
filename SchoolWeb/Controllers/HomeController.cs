using System.Web.Mvc;
using SampleEntityFramework.DataAccess;
using SampleEntityFramework.DataAccess.Queries.Students;

namespace SampleEntityFramework.SchoolWeb.Controllers
{
    public class HomeController : ControllerBase
    {
        private readonly ISchoolContext _context;

        public HomeController()
        {
            _context = new SchoolContext();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}
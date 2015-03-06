using System.Web.Mvc;
using SampleEntityFramework.DataAccess;
using SampleEntityFramework.DataAccess.Queries.Courses;

namespace SampleEntityFramework.SchoolWeb.Controllers
{
    public class CourseController : ControllerBase
    {
        private readonly ISchoolContext _context;

        public CourseController(ISchoolContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Index(CourseListQuery query)
        {
            return View(query.Execute(_context));
        }

        [HttpGet]
        public ActionResult Detail(CourseDetailsQuery query)
        {
            return ViewIfNotNull(query.Execute(_context));
        }
    }
}
using System.Web.Mvc;
using SampleEntityFramework.DataAccess;
using SampleEntityFramework.DataAccess.Queries.Courses;
using SampleEntityFramework.DataAccess.Queries.Students;

namespace SampleEntityFramework.SchoolWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISchoolContext _context;

        public HomeController()
        {
            _context = new SchoolContext();
        }

        [HttpGet]
        public ActionResult Index(CourseListQuery query)
        {
            return View(query.Execute(_context));
        }

        [HttpGet]
        public ActionResult Course(CourseDetailsQuery query)
        {
            return ViewIfNotNull(query.Execute(_context));
        }

        [HttpGet]
        public ActionResult Student(StudentDetailsQuery query)
        {
            return ViewIfNotNull(query.Execute(_context));
        }

        protected ViewResult ViewIfNotNull(object model)
        {
            return model == null
                ? View("NotFound")
                : View(model);
        }
    }
}
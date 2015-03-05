using System.Web.Mvc;
using SampleEntityFramework.DataAccess;
using SampleEntityFramework.DataAccess.Queries.Students;

namespace SampleEntityFramework.SchoolWeb.Controllers
{
    public class StudentController : ControllerBase
    {
        private readonly ISchoolContext _context;

        public StudentController()
        {
            _context = new SchoolContext();
        }

        [HttpGet]
        public ActionResult Index(StudentListQuery query)
        {
            return View(query.Execute(_context));
        }

        [HttpGet]
        public ActionResult Detail(StudentDetailsQuery query)
        {
            return ViewIfNotNull(query.Execute(_context));
        }
    }
}
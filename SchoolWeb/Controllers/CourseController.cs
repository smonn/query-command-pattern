using System.Web.Mvc;
using SampleEntityFramework.DataAccess;
using SampleEntityFramework.DataAccess.Commands.Courses;
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

        [HttpGet]
        public ActionResult Create()
        {
            return View("Edit", new EditCourseCommand());
        }

        [HttpGet]
        public ActionResult Edit(CourseDetailsQuery query)
        {
            var student = query.Execute(_context);
            var command = new EditCourseCommand
            {
                CourseId = student.Details.CourseId,
                Title = student.Details.Title,
                Credits = student.Details.Credits,
            };
            return View(command);
        }

        [HttpPost]
        public ActionResult Update(EditCourseCommand command)
        {
            if (!ModelState.IsValid) return View("Edit", command);
            var studentId = command.Execute(_context);
            return RedirectToAction("Detail", new { id = studentId });
        }
    }
}
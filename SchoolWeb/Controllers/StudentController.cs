using System.Web.Mvc;
using SampleEntityFramework.DataAccess;
using SampleEntityFramework.DataAccess.Commands.Students;
using SampleEntityFramework.DataAccess.Queries.Students;

namespace SampleEntityFramework.SchoolWeb.Controllers
{
    public class StudentController : ControllerBase
    {
        private readonly ISchoolContext _context;

        public StudentController(ISchoolContext context)
        {
            _context = context;
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

        [HttpGet]
        public ActionResult Create()
        {
            return View("Edit", new EditStudentCommand());
        }

        [HttpGet]
        public ActionResult Edit(StudentDetailsQuery query)
        {
            var student = query.Execute(_context);
            if (student == null) return ViewIfNotNull(null);
            var command = new EditStudentCommand
            {
                EnrollmentDate = student.Details.EnrollmentDate,
                FirstName = student.Details.FirstName,
                LastName = student.Details.LastName,
                StudentId = student.Details.StudentId,
            };
            return View(command);
        }

        [HttpPost]
        public ActionResult Update(EditStudentCommand command)
        {
            if (!ModelState.IsValid) return View("Edit", command);
            var studentId = command.Execute(_context);
            return RedirectToAction("Detail", new { id = studentId });
        }
    }
}
using System;
using System.Web.Mvc;
using SampleEntityFramework.DataAccess;
using SampleEntityFramework.DataAccess.Commands.Courses;
using SampleEntityFramework.DataAccess.Queries.Courses;
using SampleEntityFramework.Utilities.Exceptions;

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
            var course = query.Execute(_context);
            if (course == null) return ViewIfNotNull(null);
            var command = new EditCourseCommand
            {
                CourseId = course.Details.CourseId,
                Title = course.Details.Title,
                Credits = course.Details.Credits,
                CourseCode = course.Details.CourseCode,
            };
            return View(command);
        }

        [HttpPost]
        public ActionResult Update(EditCourseCommand command)
        {
            if (!ModelState.IsValid) return View("Edit", command);
            try
            {
                var courseCode = command.Execute(_context);
                return RedirectToAction("Detail", new {id = courseCode});
            }
            catch (CourseCodeException ex)
            {
                ModelState.AddModelError("CourseCode", ex.Message);
                return View("Edit", command);
            }
        }
    }
}
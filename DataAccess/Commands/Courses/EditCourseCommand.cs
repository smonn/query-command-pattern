using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Migrations;
using System.Linq;
using SampleEntityFramework.Utilities.Exceptions;

namespace SampleEntityFramework.DataAccess.Commands.Courses
{
    public class EditCourseCommand : ICommand<int>
    {
        public int CourseId { get; set; }

        [Range(1000, 9999)]
        [Display(Name = "Course Code")]
        public int CourseCode { get; set; }

        [Required]
        [MaxLength(64), MinLength(4)]
        public string Title { get; set; }

        [Required]
        public int Credits { get; set; }

        public int Execute(ISchoolContext context)
        {
            var otherCourse = context.Courses.Any(c => c.CourseId != CourseId && c.CourseCode == CourseCode);
            if (otherCourse)
                throw new CourseCodeException();

            var course = context.Courses.Any(c => c.CourseId == CourseId)
                ? context.Courses.First(c => c.CourseId == CourseId)
                : context.Courses.Create();

            course.CourseCode = CourseCode;
            course.Title = Title;
            course.Credits = Credits;

            context.Courses.AddOrUpdate(course);
            context.Commit();

            return course.CourseCode;
        }
    }
}
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using SampleEntityFramework.PersistenceModels;

namespace SampleEntityFramework.DataAccess.Commands.Courses
{
    public class EditCourseCommand : ICommand<int>
    {
        public int CourseId { get; set; }

        [Required]
        [MaxLength(64), MinLength(4)]
        public string Title { get; set; }

        [Required]
        public int Credits { get; set; }

        public int Execute(ISchoolContext context)
        {
            var oldCourseExists = context.Courses.Any(c => c.CourseId == CourseId);
            var course = oldCourseExists
                ? context.Courses.First(c => c.CourseId == CourseId)
                : context.Courses.Create();

            course.Title = Title;
            course.Credits = Credits;

            context.Courses.AddOrUpdate(course);
            context.Commit();

            return course.CourseId;
        }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Migrations;
using System.Linq;

namespace SampleEntityFramework.DataAccess.Commands
{
    public class EditStudentCommand : ICommand<int>
    {
        public int StudentId { get; set; }

        [Required]
        [MaxLength(32), MinLength(1)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(32), MinLength(1)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }

        public EditStudentCommand()
        {
            EnrollmentDate = DateTime.Today;
        }

        public int Execute(ISchoolContext context)
        {
            var student = context.Students.Any(s => s.StudentId == StudentId)
                ? context.Students.First(s => s.StudentId == StudentId)
                : context.Students.Create();

            student.FirstName = FirstName;
            student.LastName = LastName;
            student.EnrollmentDate = EnrollmentDate;

            context.Students.AddOrUpdate(student);
            context.Commit();

            return student.StudentId;
        }
    }
}
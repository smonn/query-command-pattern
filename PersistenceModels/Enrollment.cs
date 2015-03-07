using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleEntityFramework.PersistenceModels
{
    public class Enrollment
    {
        [Key]
        public int EnrollmentId { get; set; }

        [Index]
        public int CourseId { get; set; }

        [Index]
        public int StudentId { get; set; }

        [Required]
        public int GradeValue { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}
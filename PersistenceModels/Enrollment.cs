using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleEntityFramework.PersistenceModels
{
    // todo turn into proper enumeration class
    public enum EnrollmentGrade
    {
        X, F, D, C, B, A,
    }

    public class Enrollment
    {
        [Key]
        [Column(Order = 1)]
        public int CourseId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int StudentId { get; set; }

        [Required]
        public EnrollmentGrade Grade { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}
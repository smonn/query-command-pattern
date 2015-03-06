using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleEntityFramework.PersistenceModels
{
    public class Enrollment
    {
        [Key]
        [Column(Order = 1)]
        public int CourseId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int StudentId { get; set; }

        [Required]
        public int GradeValue { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}
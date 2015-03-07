using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleEntityFramework.PersistenceModels
{
    public class Course
    {
        public int CourseId { get; set; }

        [Index(IsUnique = true)]
        [Range(1000, 9999)]
        [ConcurrencyCheck]
        public int CourseCode { get; set; }

        [Required]
        [MaxLength(64), MinLength(4)]
        public string Title { get; set; }

        [Required]
        public int Credits { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
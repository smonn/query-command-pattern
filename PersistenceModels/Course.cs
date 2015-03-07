using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleEntityFramework.PersistenceModels
{
    public class Course
    {
        // todo disable manual setting of this id
        // todo introduce another field that takes care of this (e.g. CourseCode)
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseId { get; set; }

        [Required]
        [MaxLength(64), MinLength(4)]
        public string Title { get; set; }

        [Required]
        public int Credits { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SampleEntityFramework.PersistenceModels
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        [MaxLength(32), MinLength(1)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(32), MinLength(1)]
        public string LastName { get; set; }

        [Required]
        public DateTime EnrollmentDate { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
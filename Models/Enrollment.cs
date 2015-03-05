namespace SampleEntityFramework.PersistenceModels
{
    public enum EnrollmentGrade
    {
        X, F, D, C, B, A,
    }

    public class Enrollment
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public EnrollmentGrade Grade { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}
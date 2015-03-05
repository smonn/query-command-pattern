using SampleEntityFramework.PersistenceModels;

namespace SampleEntityFramework.DomainModels.Courses
{
    public class CourseEnrollmentListModel
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public EnrollmentGrade Grade { get; set; }
    }
}
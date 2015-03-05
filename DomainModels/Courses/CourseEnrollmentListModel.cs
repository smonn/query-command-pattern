using SampleEntityFramework.PersistenceModels;

namespace SampleEntityFramework.DomainModels.Courses
{
    public class CourseEnrollmentListModel : CourseListModel
    {
        public EnrollmentGrade Grade { get; set; }
    }
}
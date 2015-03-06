using SampleEntityFramework.PersistenceModels;

namespace SampleEntityFramework.DomainModels.Courses
{
    public class CourseEnrollmentListModel : CourseListModel
    {
        public int GradeValue { get; set; }

        public EnrollmentGrade Grade
        {
            get { return EnrollmentGrade.FromValue(GradeValue); }
            set { GradeValue = value.Value; }
        }
    }
}
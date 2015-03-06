using SampleEntityFramework.PersistenceModels;

namespace SampleEntityFramework.DomainModels.Students
{
    public class StudentEnrollmentListModel : StudentListModel
    {
        public int GradeValue { get; set; }

        public EnrollmentGrade Grade
        {
            get { return EnrollmentGrade.FromValue(GradeValue); }
            set { GradeValue = value.Value; }
        }
    }
}
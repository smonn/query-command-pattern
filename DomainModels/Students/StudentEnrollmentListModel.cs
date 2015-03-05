using SampleEntityFramework.PersistenceModels;

namespace SampleEntityFramework.DomainModels.Students
{
    public class StudentEnrollmentListModel : StudentListModel
    {
        public EnrollmentGrade Grade { get; set; }
    }
}
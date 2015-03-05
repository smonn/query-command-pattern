using SampleEntityFramework.PersistenceModels;

namespace SampleEntityFramework.DomainModels.Students
{
    public class StudentEnrollmentListModel
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public EnrollmentGrade Grade { get; set; }
    }
}
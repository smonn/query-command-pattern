namespace SampleEntityFramework.DomainModels.Students
{
    public class StudentListModel
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int EnrollmentCount { get; set; }
    }
}
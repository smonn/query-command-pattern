namespace SampleEntityFramework.DomainModels.Courses
{
    public class CourseListModel
    {
        public int CourseId { get; set; }
        public int CourseCode { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public int EnrollmentCount { get; set; }
    }
}
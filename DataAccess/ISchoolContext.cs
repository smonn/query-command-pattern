using System.Data.Entity;
using SampleEntityFramework.PersistenceModels;

namespace SampleEntityFramework.DataAccess
{
    public interface ISchoolContext
    {
        IDbSet<Student> Students { get; set; }
        IDbSet<Enrollment> Enrollments { get; set; }
        IDbSet<Course> Courses { get; set; }

        void Commit();
    }
}
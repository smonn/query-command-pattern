using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using SampleEntityFramework.PersistenceModels;

namespace SampleEntityFramework.DataAccess
{
    public class SchoolContext : DbContext, ISchoolContext
    {
        public SchoolContext() : base("SchoolContext") { }

        public IDbSet<Student> Students { get; set; }
        public IDbSet<Enrollment> Enrollments { get; set; }
        public IDbSet<Course> Courses { get; set; }

        public void Commit()
        {
            SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
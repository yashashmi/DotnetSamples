using SomeUniversity.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SomeUniversity.Data
{
    public class SchoolContext : DbContext
    {

        public SchoolContext(string con) : base(con)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
using System.Data.Entity.Infrastructure;

namespace SomeUniversity.Data
{
    public class SchoolContextFactory : IDbContextFactory<SchoolContext>
    {
        public SchoolContext Create()
        {
            return new SchoolContext("Server=(LocalDb)\\MSSQLLocalDB;Initial Catalog=SomeUniversity2;Integrated Security=SSPI;");
        }
    }
}

namespace DependencyInjection.Web.Entities
{
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var _connectionString =
                @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=IocLunchAndLearn;
                    Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;
                    ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            optionsBuilder.UseSqlServer(_connectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
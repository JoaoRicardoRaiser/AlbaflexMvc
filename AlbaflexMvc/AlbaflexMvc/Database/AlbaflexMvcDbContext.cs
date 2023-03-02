using System.Reflection.Emit;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace AlbaflexMvc.Database
{
    public class AlbaflexDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(DbInfoProvider.GetPostgresConnectionString());

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

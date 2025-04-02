using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace User.Infrastructure.Persistence
{
    public class UserContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Domain.Entities.User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

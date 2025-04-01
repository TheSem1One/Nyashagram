using System.Reflection;
using User.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace User.Infrastructure.Persistence
{
    public class UserContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<User.Domain.Entities.User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

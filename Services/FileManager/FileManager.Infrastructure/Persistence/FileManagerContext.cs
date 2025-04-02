using System.Reflection;
using Microsoft.EntityFrameworkCore;
using File = FileManager.Domain.Entities.File;

namespace FileManager.Infrastructure.Persistence
{
    public class FileManagerContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<File> Files { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
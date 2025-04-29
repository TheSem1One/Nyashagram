using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using FileManager.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FileManager.Infrastructure.Helpers
{
    public static class DbExtension
    {
        public static void ApplyMigration(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();
            using FileManagerContext dbContext =
                scope.ServiceProvider.GetRequiredService<FileManagerContext>();
            var pendingMigrations = dbContext.Database.GetPendingMigrations();
            if (pendingMigrations.Any())
            {
                dbContext.Database.Migrate();
            }
            dbContext.Database.Migrate();
        }
    }
}

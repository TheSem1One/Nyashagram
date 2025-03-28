using Auth.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;

namespace Auth.Infrastructure.Helpers
{
    public static class DBExtension
    {
        public static void ApplyMigration(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();
            using UserContext dbContext =
                scope.ServiceProvider.GetRequiredService<UserContext>();

            dbContext.Database.Migrate();
        }
    }
}

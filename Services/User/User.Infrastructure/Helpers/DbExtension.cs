using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using User.Infrastructure.Persistence;

namespace User.Infrastructure.Helpers
{
    public static class DbExtension
    {
        public static void ApplyMigration(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();
            using UserContext dbContext =
                scope.ServiceProvider.GetRequiredService<UserContext>();

            // dbContext.Database.Migrate();
        }
    }
}

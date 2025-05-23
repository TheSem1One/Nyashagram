﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using User.Infrastructure.Persistence;

namespace User.Infrastructure.Helpers
{
    public static class DbExtension
    {
        public static void ApplyMigration(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();
            using UserContext dbContext = scope.ServiceProvider.GetRequiredService<UserContext>();

            var pendingMigrations = dbContext.Database.GetPendingMigrations();
            if (pendingMigrations.Any())
            {
                dbContext.Database.Migrate();
            }
        }
    }
}

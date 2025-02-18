using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Auth.Infrastructure.Persistence 
{
    public class DatabaseConfig(IConfiguration configuration) : DbContext
    {
        protected readonly IConfiguration _configuration = configuration;

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(_configuration.GetConnectionString("ApiDatabase"));
        }

      
    }
}

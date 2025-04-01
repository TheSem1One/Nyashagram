using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace FileManager.Infrastructure.Persistance
{
    public class DatabaseConfig(IConfiguration configuration) : DbContext
    {
        private readonly IConfiguration _configuration = configuration;

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(_configuration.GetConnectionString("ApiDatabase"));
        }


    }
}

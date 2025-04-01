using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Stories.Domain.Entity;

namespace Stories.Infrastructure.Persistence
{
    public class StoriesContext : IStoriesContext
    {
        private readonly IConfiguration _iConfiguration;
        public IMongoCollection<Short> Shorts { get; set; }

        public StoriesContext(IConfiguration iConfiguration)
        {
            _iConfiguration = iConfiguration;
            var client = new MongoClient(_iConfiguration.GetConnectionString("DbConnection"));
            var database = client.GetDatabase(_iConfiguration.GetConnectionString("DbName"));
            Shorts = database.GetCollection<Short>(_iConfiguration.GetConnectionString("DbCollection"));

        }
    }
}

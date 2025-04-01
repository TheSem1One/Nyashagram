using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Post.Infrastructure.Persistence
{
    public class PostContext : IPostContext
    {
        private readonly IConfiguration _configuration;
        public IMongoCollection<Domain.Entities.Post> Post { get; }

        public PostContext(IConfiguration iConfiguration)
        {
            _configuration = iConfiguration;
            var client = new MongoClient(_configuration.GetConnectionString("DbConnection"));
            var database = client.GetDatabase(_configuration.GetConnectionString("DbName"));
            Post = database.GetCollection<Domain.Entities.Post>(_configuration.GetConnectionString("DbCollection"));

        }
    }

}

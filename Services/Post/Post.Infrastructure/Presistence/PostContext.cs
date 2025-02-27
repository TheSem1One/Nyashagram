using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Post.Infrastructure.Presistence
{
    public class PostContext : IPostContext
    {
        private readonly IConfiguration _iConfiguration;
        public IMongoCollection<Domain.Entities.Post> Post { get;}

        public PostContext(IConfiguration iConfiguration)
        {
            _iConfiguration = iConfiguration;
            var client = new MongoClient(_iConfiguration.GetConnectionString("DbConnection"));
            var database = client.GetDatabase(_iConfiguration.GetConnectionString("DbName"));
            Post = database.GetCollection<Domain.Entities.Post>(_iConfiguration.GetConnectionString("DbCollection"));

        }
    }
    
}

using MongoDB.Driver;

namespace Post.Infrastructure.Persistence
{
    public interface IPostContext
    {
        IMongoCollection<Domain.Entities.Post> Post { get; }

    }
}

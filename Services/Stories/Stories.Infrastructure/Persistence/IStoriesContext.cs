using MongoDB.Driver;
using Stories.Domain.Entity;

namespace Stories.Infrastructure.Persistence
{
    public interface IStoriesContext
    {
        IMongoCollection<Short> Shorts { get; set; }

    }
}

using MongoDB.Driver;
using Stories.Domain.Entity;

namespace Stories.Infrastructure.Presistence
{
    public interface IStoriesContext
    {
        IMongoCollection<Short> Shorts { get; set; }

    }
}

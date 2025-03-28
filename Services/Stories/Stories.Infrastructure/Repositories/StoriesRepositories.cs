using MongoDB.Bson;
using MongoDB.Driver;
using Stories.Domain.Entity;
using Stories.Domain.Entity.DTO;
using Stories.Domain.Repositories;
using Stories.Infrastructure.Presistence;

namespace Stories.Infrastructure.Repositories
{
    public class StoriesRepositories : IStoriesRepository
    {
        private readonly IStoriesContext _context;
        public StoriesRepositories(IStoriesContext context)
        {
            _context = context;
        }
        async Task<string> IStoriesRepository.CreateStories(ShortsDTO Dto)
        {
            var stories = new Short
            {
                CreatorNickName = Dto.CreatorNickName,
                StoriesImageUrl = Dto.StoriesImageUrl,
                ExpireTime = DateTime.Now.AddDays(1)
            };
            await _context.Shorts.InsertOneAsync(stories);
            return stories.StoriesId;
        }

        async Task<bool> IStoriesRepository.DeleteStories(string id)
        {
            var deleteShorts = await _context
                .Shorts
                .DeleteOneAsync(s=>s.StoriesId== id);
            return deleteShorts.IsAcknowledged & deleteShorts.DeletedCount > 0;
        }


        async Task<Short> IStoriesRepository.GetStoriesById(string id)
        {
            return await _context
                .Shorts
                .Find(stories => stories.StoriesId == id)
                .FirstOrDefaultAsync();
        }

        async Task<IEnumerable<Short>> IStoriesRepository.GetStoriesNickName(string nickName)
        {
            return await _context.Shorts
                .Find(s => s.CreatorNickName.ToLower() == nickName.ToLower())
                .ToListAsync();
        }
    }
}

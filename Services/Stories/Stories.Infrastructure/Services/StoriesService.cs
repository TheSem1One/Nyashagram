using MongoDB.Driver;
using Stories.Domain.Entity;
using Stories.Domain.Entity.DTO;
using Stories.Domain.Repositories;
using Stories.Infrastructure.Persistence;

namespace Stories.Infrastructure.Services
{
    public class StoriesService(IStoriesContext context) : IStoriesRepository
    {
        private readonly IStoriesContext _context = context;

        public async Task<string> CreateStory(ShortsDTO dto)
        {
            var story = new Short
            {
                CreatorNickName = dto.CreatorNickName,
                StoryImageUrl = dto.StoryImageUrl,
                ExpireTime = DateTime.Now.AddDays(1)
            };
            await _context.Shorts.InsertOneAsync(story);
            return story.StoryId;
        }

        public async Task<bool> DeleteStory(string id)
        {
            var deleteShorts = await _context
                .Shorts
                .DeleteOneAsync(s => s.StoryId == id);
            return deleteShorts.IsAcknowledged & deleteShorts.DeletedCount > 0;
        }


        public async Task<Short> GetStoryById(string id)
        {
            return await _context
                .Shorts
                .Find(stories => stories.StoryId == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Short>> GetStoryNickName(string nickName)
        {
            return await _context.Shorts
                .Find(s => s.CreatorNickName.ToLower() == nickName.ToLower())
                .ToListAsync();
        }
    }
}

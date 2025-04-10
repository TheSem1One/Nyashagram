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

        public async Task<bool> Like(LikeDto dto)
        {
            var postFilter = Builders<Short>.Filter.Eq(p => p.StoryId, dto.StoryId);
            var existingPost = await _context.Shorts.Find(postFilter).FirstOrDefaultAsync();
            if (existingPost.Likes.LikesNickName.Contains(dto.NickName))
            {
                var update = Builders<Short>.Update
                    .Inc(p => p.Likes.CountLike, -1)
                    .Pull(p => p.Likes.LikesNickName, dto.NickName);
                var result = await _context.Shorts.UpdateOneAsync(postFilter, update);
                return result.ModifiedCount > 0;
            }
            else
            {
                var update = Builders<Short>.Update
                    .Inc(p => p.Likes.CountLike, 1)
                    .Push(p => p.Likes.LikesNickName, dto.NickName);
                var result = await _context.Shorts.UpdateOneAsync(postFilter, update);
                return result.ModifiedCount > 0;
            }
        }
    }
}

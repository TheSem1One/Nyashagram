using Stories.Domain.Entity;
using Stories.Domain.Entity.DTO;

namespace Stories.Domain.Repositories
{
    public interface IStoriesRepository
    {
        Task<IEnumerable<Short>> GetStoryNickName(string nickName);
        Task<Short> GetStoryById(string id);
        Task<string> CreateStory(ShortsDTO shortsDto);
        Task<bool> DeleteStory(string id);
        Task<bool> Like(LikeDto dto);
    }
}

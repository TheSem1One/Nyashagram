using User.Domain.DTO;
using User.Domain.DTO.Profile;

namespace User.Domain.Repositories
{
    public interface IProfile
    {
        Task<bool> UpdateProfile(UpdateProfileDto updateProfileDto);
        Task<bool> AddPost(PostDto postDto);
        Task<bool> DeletePost(PostDto postDto);
        Task<bool> AddStory(StoryDto storyDto);
        Task<bool> DeleteStory(StoryDto storyDto);
        Task<Entities.User> GetProfile(string nickName);
        Task<bool> AddToFavorite(FavoritePost favorite);


    }
}

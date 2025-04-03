using User.Domain.DTO;

namespace User.Domain.Repositories
{
    public interface IProfile
    {
        Task<bool> UpdateProfile(ProfileDto profileDto);
        Task<bool> AddPost(PostDto postDto);
        Task<bool> DeletePost(PostDto postDto);
        Task<bool> AddStory(StoryDto storyDto);
        Task<bool> DeleteStory(StoryDto storyDto);
        Task<bool> Subscribe(SubscribeDto subscribeDto);
        Task<bool> Unsubscribe(SubscribeDto subscribeDto);
        Task<Entities.User> GetProfile(string nickName);


    }
}

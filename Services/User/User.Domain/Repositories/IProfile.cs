using User.Domain.DTO;

namespace User.Domain.Repositories
{
    public interface IProfile
    {
        Task<bool> UpdateProfile(ProfileDto profileDto);
        Task<bool> Subscribe(string currentUser, string targetNickName);
        Task<bool> Unscribe(string currentUser ,string targetNickName);
        Task<Entities.User> GetProfile(string nickName);


    }
}

using User.Domain.DTO;

namespace User.Domain.Repositories
{
    public interface IProfile
    {
        Task<Entities.User> UpdateProfile(ProfileDto profileDto);

    }
}

using User.Domain.DTO;

namespace User.Domain.Repositories
{
    public interface IProfile
    {
        Task<bool> UpdateProfile(ProfileDto profileDto);

    }
}

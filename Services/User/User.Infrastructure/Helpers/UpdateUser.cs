using User.Domain.DTO;

namespace User.Infrastructure.Helpers
{
    public class UpdateUser
    {
        public Domain.Entities.User Update(Domain.Entities.User user, ProfileDto profileDto)
        {
            if (profileDto.ImageUrl != null) user.ImageUrl = profileDto.ImageUrl;
            if (profileDto.BirthDate != null) user.BirthDate = profileDto.BirthDate;
            if (profileDto.Description != null) user.Description = profileDto.Description;
            return user;
        }
    }
}

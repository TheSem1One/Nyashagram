using System.Globalization;
using User.Domain.DTO;
using User.Domain.DTO.Profile;

namespace User.Infrastructure.Helpers
{
    public class UpdateUser
    {
        public Domain.Entities.User Update(Domain.Entities.User user, UpdateProfileDto updateProfileDto)
        {
            if (!string.IsNullOrEmpty(updateProfileDto.ImageUrl)) user.ImageUrl = updateProfileDto.ImageUrl;
            if (!string.IsNullOrEmpty(updateProfileDto.BirthDate))
            {
                var dateString = updateProfileDto.BirthDate;
                DateOnly result;
                bool isValidDate = DateOnly.TryParseExact(dateString, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out result);
                if (isValidDate)
                {
                    var date = DateOnly.Parse(dateString);

                    user.BirthDate = date;
                }
            }
            if (!string.IsNullOrEmpty(updateProfileDto.Description)) user.Description = updateProfileDto.Description;
            return user;
        }
    }
}

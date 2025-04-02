using System.Globalization;
using User.Domain.DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace User.Infrastructure.Helpers
{
    public class UpdateUser
    {
        public Domain.Entities.User Update(Domain.Entities.User user, ProfileDto profileDto)
        {
            if (!string.IsNullOrEmpty(profileDto.ImageUrl)) user.ImageUrl = profileDto.ImageUrl;
            if (!string.IsNullOrEmpty(profileDto.BirthDate))
            {
                var dateString = profileDto.BirthDate;
                DateOnly result;
                bool isValidDate = DateOnly.TryParseExact(dateString, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out result);
                if (isValidDate)
                {
                    var date = DateOnly.Parse(dateString);

                    user.BirthDate = date;
                }
            }
            if (!string.IsNullOrEmpty(profileDto.Description)) user.Description = profileDto.Description;
            return user;
        }
    }
}

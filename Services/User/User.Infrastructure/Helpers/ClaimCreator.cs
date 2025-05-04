using User.Domain.DTO;
using User.Domain.DTO.Profile;

namespace User.Infrastructure.Helpers
{
    public class ClaimCreator
    {
        public List<System.Security.Claims.Claim> GetClaims(ProfileDto profileDto)
        {
            var claims = new List<System.Security.Claims.Claim>
            {
                new System.Security.Claims.Claim("NickName", profileDto.NickName ?? string.Empty),
            };

            return claims;
        }
    }
}


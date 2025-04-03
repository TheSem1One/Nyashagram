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

            if (profileDto.BirthDate.HasValue)
                claims.Add(new System.Security.Claims.Claim("BirthDate", profileDto.BirthDate.Value.ToString("yyyy-MM-dd")));

            if (profileDto.Subscriptions?.Any() == true)
                claims.Add(new System.Security.Claims.Claim("Subcriptions", string.Join(",", profileDto.Subscriptions)));

            if (profileDto.Subscribers?.Any() == true)
                claims.Add(new System.Security.Claims.Claim("Subscribers", string.Join(",", profileDto.Subscribers)));

            if (profileDto.Posts?.Any() == true)
                claims.Add(new System.Security.Claims.Claim("Posts", string.Join(",", profileDto.Posts)));

            if (profileDto.StoriesList?.Any() == true)
                claims.Add(new System.Security.Claims.Claim("StoriesList", string.Join(",", profileDto.StoriesList)));

            return claims;
        }
    }
}


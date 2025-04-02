using User.Domain.DTO;

namespace User.Infrastructure.Helpers
{
    public class ClaimCreator
    {
        public List<System.Security.Claims.Claim> GetClaims(UserDto userDto)
        {
            var claims = new List<System.Security.Claims.Claim>
            {
                new System.Security.Claims.Claim("NickName", userDto.NickName ?? string.Empty),
            };

            if (userDto.BirthDate.HasValue)
                claims.Add(new System.Security.Claims.Claim("BirthDate", userDto.BirthDate.Value.ToString("yyyy-MM-dd")));

            if (userDto.Subscriptions?.Any() == true)
                claims.Add(new System.Security.Claims.Claim("Subcriptions", string.Join(",", userDto.Subscriptions)));

            if (userDto.Subscribers?.Any() == true)
                claims.Add(new System.Security.Claims.Claim("Subscribers", string.Join(",", userDto.Subscribers)));

            if (userDto.Posts?.Any() == true)
                claims.Add(new System.Security.Claims.Claim("Posts", string.Join(",", userDto.Posts)));

            if (userDto.StoriesList?.Any() == true)
                claims.Add(new System.Security.Claims.Claim("StoriesList", string.Join(",", userDto.StoriesList)));

            if (userDto.SavedPosts?.Any() == true)
                claims.Add(new System.Security.Claims.Claim("SavedPosts", string.Join(",", userDto.SavedPosts)));

            return claims;
        }
    }
}


using User.Domain.DTO;

namespace User.Infrastructure.Helpers
{
    public class ClaimCreator
    {
        public List<System.Security.Claims.Claim> GetClaims(UserDTO user)
        {
            var claims = new List<System.Security.Claims.Claim>
            {
                new System.Security.Claims.Claim("NickName", user.NickName ?? string.Empty),
                new System.Security.Claims.Claim("PrivateProfile", user.PrivateProfile.ToString())
            };

            if (user.BirthDate.HasValue)
                claims.Add(new System.Security.Claims.Claim("BirthDate", user.BirthDate.Value.ToString("yyyy-MM-dd")));

            if (user.Subcriptions?.Any() == true)
                claims.Add(new System.Security.Claims.Claim("Subcriptions", string.Join(",", user.Subcriptions)));

            if (user.Subscribers?.Any() == true)
                claims.Add(new System.Security.Claims.Claim("Subscribers", string.Join(",", user.Subscribers)));

            if (user.Posts?.Any() == true)
                claims.Add(new System.Security.Claims.Claim("Posts", string.Join(",", user.Posts)));

            if (user.StoriesList?.Any() == true)
                claims.Add(new System.Security.Claims.Claim("StoriesList", string.Join(",", user.StoriesList)));

            if (user.SavedPosts?.Any() == true)
                claims.Add(new System.Security.Claims.Claim("SavedPosts", string.Join(",", user.SavedPosts)));

            return claims;
        }
    }
}


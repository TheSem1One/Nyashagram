using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Auth.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;


namespace Auth.Infrastructure.Helpers
{
    public class TokenManipulation(UserContext userContext, IConfiguration configuration)
    {
        private readonly UserContext _userContext = userContext;
        protected readonly IConfiguration _configuration = configuration;

        public string CreateToken(string email, string password)
        {
            var strSecretKey = "qwertyuiop[]';lkhhgfdfddsasxcvbnmm,";
            var expiresAt = DateTime.UtcNow.AddYears(20);
            /*var app = _userContext.Users.FirstOrDefault(p => p.email == email);*/

            var claims = new List<Claim>
            {
                new Claim ("Email", email??string.Empty),
                new Claim ("Password", password??string.Empty)
            };
            var secretKey = Encoding.ASCII.GetBytes(strSecretKey);
            var jwt = new JwtSecurityToken(
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(secretKey),
                    SecurityAlgorithms.HmacSha256Signature),
                claims: claims,
                expires: expiresAt,
                notBefore: DateTime.UtcNow
            );
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}

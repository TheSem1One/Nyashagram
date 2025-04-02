using System.IdentityModel.Tokens.Jwt;
using System.Text;
using User.Domain.DTO;
using Microsoft.IdentityModel.Tokens;

namespace User.Infrastructure.Helpers
{
    public class TokenManipulation(UserIdentity userIdentity, ClaimCreator claim)
    {
        private readonly UserIdentity _userIdentity = userIdentity;
        private readonly ClaimCreator _claim = claim;
        public string CreateToken(string email, string password)
        {
            UserDTO user = _userIdentity.GetJwtUser(email);
            var strSecretKey = "qwertyuiop[]';lkhhgfdfddsasxcvbnmm,";
            var expiresAt = DateTime.UtcNow.AddYears(20);


            var claims = _claim.GetClaims(user);
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

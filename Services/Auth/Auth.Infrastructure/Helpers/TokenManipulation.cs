using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;


namespace Auth.Infrastructure.Helpers
{
    internal class TokenManipulation
    {
        public string CreateToken(string email, string password, DateTime expiresAt, string strSecretKey)
        {


            var app = _appReposetory.GetUserByEmail(email);
            var claism = new List<Claim>
            {
                new Claim ("Email", app.Email??string.Empty),
                new Claim ("Password", app.Password??string.Empty),
                new Claim ("Name", app.Name??string.Empty),
                new Claim ("Scopes",(app?.Scopes??string.Empty).Contains("User")?"true":"false"),
            };
            var secretKey = Encoding.ASCII.GetBytes(strSecretKey);
            var jwt = new JwtSecurityToken(
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(secretKey),
                    SecurityAlgorithms.HmacSha256Signature),
                claims: claism,
                expires: expiresAt,
                notBefore: DateTime.UtcNow
            );
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}

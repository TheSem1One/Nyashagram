using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Auth.Infrastructure.Configuration;
using Microsoft.IdentityModel.Tokens;


namespace Auth.Infrastructure.Helpers
{
    public class TokenManipulation
    {
        protected readonly FindUser _findUser;
        public TokenManipulation(FindUser findUser)
        {
            _findUser=findUser;
        }
        
        public string CreateToken(string email, string password, DateTime expiresAt, string strSecretKey)
        {


            var app =_findUser.GetUserByEmail(email);
            var claism = new List<Claim>
            {
                new Claim ("Email", app.email??string.Empty),
                new Claim ("Password", app.password??string.Empty),
                new Claim ("Name", app.nickName??string.Empty),
                
                
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

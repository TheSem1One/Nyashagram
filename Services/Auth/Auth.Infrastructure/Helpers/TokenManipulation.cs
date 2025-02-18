using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Auth.Infrastructure.Configuration;
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
            var strSecretKey = _configuration.GetConnectionString("LolKekCheburek");
            var expiresAt = DateTime.UtcNow.AddMinutes(400);
            var app = _userContext.Users.FirstOrDefault(p=>p.email==email);

            var claism = new List<Claim>
            {
                new Claim ("Email", app.email??string.Empty),
                new Claim ("Password", app.password??string.Empty)
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

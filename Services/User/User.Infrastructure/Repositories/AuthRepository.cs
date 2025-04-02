using User.Domain.DTO;
using User.Domain.Entities;
using User.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using User.Infrastructure.Helpers;
using User.Infrastructure.Persistence;

namespace User.Infrastructure.Repositories
{
    public class AuthRepository(UserContext db, TokenManipulation tokenManipulation,
        HashPassword hashPassword, UserIdentity userIdentity) : IAuth
    {
        private readonly UserContext _db = db;
        private readonly TokenManipulation _tokenManipulation = tokenManipulation;
        private readonly HashPassword _hashPassword = hashPassword;
        private readonly UserIdentity _userIdentity = userIdentity;

        public async Task<string> CreateUser(RegisterDto registerDto)
        {
            if (await UserExist(registerDto.Email))
            {
                return "User already exist";
            }
            registerDto.Password = _hashPassword.HashingPassword(registerDto.Password);

            var user = new User.Domain.Entities.User
            {
                email = registerDto.Email,
                password = registerDto.Password,
                nickName = registerDto.NickName
            };
            var newUser = await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
            var jwtToken = _tokenManipulation.CreateToken(user.email, user.password);
            return jwtToken;

        }

        public async Task<string> LoginUser(LoginDto loginDto)
        {
            if (await UserExist(loginDto.Email))
            {
                if (_userIdentity.IsEqual(loginDto.Email, loginDto.Password))
                {
                    var jwtToken = _tokenManipulation.CreateToken(loginDto.Email, loginDto.Password);
                    return jwtToken;
                }

            }

            return "Wrong Email or Password";
        }

        public async Task<User.Domain.Entities.User> GetUserByName(string nickName)
        {

            return await _db.Users
                .FirstOrDefaultAsync(p => p.nickName == nickName);
        }



        public async Task<bool> UserExist(string email)
        {
            if (await _db.Users.AnyAsync(user => user.email.ToLower().Equals(email.ToLower())))
            {
                return true;
            }
            return false;
        }


    }
}

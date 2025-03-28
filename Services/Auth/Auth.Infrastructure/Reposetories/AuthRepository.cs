using Auth.Domain.DTO;
using Auth.Domain.Entities;
using Auth.Domain.Repositories;
using Auth.Infrastructure.Helpers;
using Auth.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Auth.Infrastructure.Reposetories
{
    public class AuthRepository : IAuth
    {
        private readonly UserContext _db;
        private readonly TokenManipulation _tokenManipulation;
        private readonly HashPassword _hashPassword;
        private readonly UserIdentity _userIdentity;

        public AuthRepository(UserContext db, TokenManipulation tokenManipulation,
            HashPassword hashPassword, UserIdentity userIdentity)
        {
            _db = db;
            _tokenManipulation = tokenManipulation;
            _hashPassword = hashPassword;
            _userIdentity = userIdentity;
        }

        async Task<string> IAuth.CreateUser(RegisterDTO registerDto)
        {
            if (await UserExist(registerDto.Email))
            {
                return "User already exist";
            }
            registerDto.Password = _hashPassword.HashingPassword(registerDto.Password);

            var user = new User
            {
                email = registerDto.Email,
                password = registerDto.Password,
                nickName = registerDto.NickName
            };
            var newUser = await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
            var jwttoken = _tokenManipulation.CreateToken(user.email, user.password);
            return jwttoken;

        }

        async Task<string> IAuth.LoginUser(LoginDTO loginDto)
        {
            if (await UserExist(loginDto.Email))
            {
                if (_userIdentity.IsEqual(loginDto.Email, loginDto.Password))
                {
                    var jwttoken = _tokenManipulation.CreateToken(loginDto.Email, loginDto.Password);
                    return jwttoken;
                }

            }

            return "Wrong Email or Password";
        }

        async Task<User> IAuth.GetUserByName(string nickName)
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

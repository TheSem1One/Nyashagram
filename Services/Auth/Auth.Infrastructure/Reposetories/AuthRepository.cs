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

        public AuthRepository(UserContext db, TokenManipulation tokenManipulation, HashPassword hashPassword)
        {
            _db = db;
            _tokenManipulation = tokenManipulation;
            _hashPassword = hashPassword;
        }

        async Task<string> IAuth.CreateUser(RegisterDTO registerDto)
        {
           if (await UserExist(registerDto.Email))
            {
                return "User already exist";
            }
            registerDto.Password = _hashPassword.HashingPassword(registerDto.Password, out var salt);

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

        async Task<User> IAuth.GetUserByName(string nickName)
        {

            return await _db.Users
                .FirstOrDefaultAsync(p => p.nickName == nickName);
        }

        Task<bool> IAuth.UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UserExist(string email)
        {
           if(await _db.Users.AnyAsync(user=>user.email.ToLower().Equals(email.ToLower())))
           {
               return true;
           }
           return false;
        }
    }
}

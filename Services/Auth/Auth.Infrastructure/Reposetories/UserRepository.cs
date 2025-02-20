
using System.Reflection.Metadata;
using Auth.Domain.Entities;
using Auth.Domain.Repositories;
using Auth.Infrastructure.Helpers;
using Auth.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Auth.Infrastructure.Reposetories
{
    public class UserRepository : IUser
    {
        private readonly UserContext _db ;
        private readonly TokenManipulation _tokenManipulation;

        public UserRepository(UserContext db, TokenManipulation tokenManipulation)
        {
            _db = db;
            _tokenManipulation = tokenManipulation;
        }
        async Task<string> IUser.CreateUser(User user)
        {
            var newUser = await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
            var jwttoken = _tokenManipulation.CreateToken(user.email, user.password);
            return  jwttoken;

        }

        async Task<User> IUser.GetUserByName(string nickName)
        {

            return await _db.Users
                .FirstOrDefaultAsync(p => p.nickName == nickName);
        }

        Task<bool> IUser.UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}

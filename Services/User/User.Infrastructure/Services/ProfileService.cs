using Microsoft.EntityFrameworkCore;
using User.Domain.DTO;
using User.Domain.Repositories;
using User.Infrastructure.Helpers;
using User.Infrastructure.Persistence;

namespace User.Infrastructure.Services
{
    public class ProfileService(UserContext db, UpdateUser updateUser) : IProfile
    {
        private readonly UserContext _db = db;
        private readonly UpdateUser _updateUser = updateUser;

        public async Task<Domain.Entities.User> GetProfile(string nickName)
        {
            var user = await _db.Users
                .SingleOrDefaultAsync(p => p.NickName.ToLower() == nickName.ToLower());
            return user;

        }

        public async Task<bool> Subscribe(string currentNickName, string targetNickName)
        {
            if (currentNickName == targetNickName) return false;
            var currentUser = await _db.Users
                .SingleOrDefaultAsync(p => p.NickName.ToLower() == currentNickName.ToLower());
            var targetUser =
                await _db.Users.SingleOrDefaultAsync(p => p.NickName.ToLower() == targetNickName.ToLower());
            currentUser.Subscriptions.Add(targetNickName);
            targetUser.Subscribers.Add(currentNickName);
            _db.Users.Update(currentUser);
            _db.Users.Update(targetUser);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Unsubscribe(string currentNickName, string targetNickName)
        {
            if (currentNickName == targetNickName) return false;
            var currentUser = await _db.Users
                .SingleOrDefaultAsync(p => p.NickName.ToLower() == currentNickName.ToLower());
            var targetUser =
                await _db.Users.SingleOrDefaultAsync(p => p.NickName.ToLower() == targetNickName.ToLower());
            currentUser.Subscriptions.Remove(targetNickName);
            targetUser.Subscribers.Remove(currentNickName);
            _db.Users.Update(currentUser);
            _db.Users.Update(targetUser);
            await _db.SaveChangesAsync();
            return true;

        }

        public async Task<bool> UpdateProfile(ProfileDto profileDto)
        {
            var user = await _db.Users.SingleOrDefaultAsync(p => p.NickName.ToLower() == profileDto.NickName.ToLower());
            var updatedUser = _updateUser.Update(user, profileDto);
            _db.Users.Update(updatedUser);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}

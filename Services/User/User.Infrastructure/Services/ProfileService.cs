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

        public async Task<bool> UpdateProfile(ProfileDto profileDto)
        {
            var user = await _db.Users.SingleOrDefaultAsync(p=>p.NickName.ToLower()==profileDto.NickName.ToLower());
            var updatedUser = _updateUser.Update(user, profileDto);
            _db.Users.Update(updatedUser);
            await _db.SaveChangesAsync();
            return true;

        }
    }
}

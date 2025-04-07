using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Web.Http;
using User.Domain.DTO;
using User.Domain.DTO.Profile;
using User.Domain.Repositories;
using User.Infrastructure.Helpers;
using User.Infrastructure.Persistence;

namespace User.Infrastructure.Services
{
    public class ProfileService(UserContext db, UpdateUser updateUser) : IProfile
    {
        private readonly UserContext _db = db;
        private readonly UpdateUser _updateUser = updateUser;

        public async Task<bool> AddPost(PostDto postDto)
        {
            var user = await _db.Users
                .SingleOrDefaultAsync(p => p.NickName.ToLower() == postDto.CreatorNickName.ToLower());
            user.Posts.Add(postDto.Id);
            _db.Users.Update(user);
            await _db.SaveChangesAsync();
            return true;

        }

        public async Task<bool> AddStory(StoryDto storyDto)
        {
            var user = await _db.Users
                .SingleOrDefaultAsync(p => p.NickName.ToLower() == storyDto.CreatorNickName.ToLower());
            user.StoriesList.Add(storyDto.Id);
            _db.Users.Update(user);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePost(PostDto postDto)
        {
            var user = await _db.Users
                .SingleOrDefaultAsync(p => p.NickName.ToLower() == postDto.CreatorNickName.ToLower());
            user.Posts.Remove(postDto.Id);
            _db.Users.Update(user);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteStory(StoryDto storyDto)
        {
            var user = await _db.Users
                .SingleOrDefaultAsync(p => p.NickName.ToLower() == storyDto.CreatorNickName.ToLower());
            user.StoriesList.Remove(storyDto.Id);
            _db.Users.Update(user);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Domain.Entities.User> GetProfile(string nickName)
        {
            var user = await _db.Users
                .SingleOrDefaultAsync(p => p.NickName.ToLower() == nickName.ToLower());
            return user;

        }

        public async Task<bool> UpdateProfile(UpdateProfileDto updateProfileDto)
        {
            var user = await _db.Users.SingleOrDefaultAsync(p => p.NickName.ToLower() == updateProfileDto.NickName.ToLower());
            var updatedUser = _updateUser.Update(user, updateProfileDto);
            _db.Users.Update(updatedUser);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}

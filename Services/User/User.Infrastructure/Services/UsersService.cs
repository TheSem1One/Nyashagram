﻿using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Web.Http;
using User.Domain.DTO;
using User.Domain.DTO.Users;
using User.Domain.Repositories;
using User.Infrastructure.Persistence;

namespace User.Infrastructure.Services
{
    public class UsersService(UserContext db) : IUsers
    {
        private readonly UserContext _db = db;
        public async Task<IEnumerable<FindDto>> FindUser(string nickName)
        {
            var users = await _db.Users
                .Where(u => EF.Functions.Like(u.NickName, $"%{nickName}%"))
                .Select(u => new FindDto
                {
                    NickName = u.NickName,
                    ImageUrl = u.ImageUrl
                })
                .ToListAsync();
            if (users is null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format($"No User with NickName = {nickName}", 404)),
                    ReasonPhrase = "User NickName Not Found"
                };
                throw new HttpResponseException(resp);
            }
            return users;
        }

        public async Task<GetUserDto> GetUserByNickName(string nickName)
        {
            var user = await _db.Users.SingleOrDefaultAsync(p => p.NickName.ToLower() == nickName.ToLower());
            var userDto = new GetUserDto()
            {
                NickName = user.NickName,
                BirthDate = user.BirthDate,
                Description = user.Description,
                ImageUrl = user.ImageUrl,
                StoriesList = user.StoriesList,
                Subscribers = user.Subscribers,
                Subscriptions = user.Subscriptions
            };
            return userDto;
        }

        public async Task<bool> Subscribe(SubscribeDto subscribeDto)
        {
            if (subscribeDto.CurrentNickName == subscribeDto.TargetNickName) return false;
            var currentUser = await _db.Users
                .SingleOrDefaultAsync(p => p.NickName.ToLower() == subscribeDto.CurrentNickName.ToLower());
            var targetUser =
                await _db.Users.SingleOrDefaultAsync(p => p.NickName.ToLower() == subscribeDto.TargetNickName.ToLower());
            currentUser.Subscriptions.Add(subscribeDto.TargetNickName);
            targetUser.Subscribers.Add(subscribeDto.CurrentNickName);
            _db.Users.Update(currentUser);
            _db.Users.Update(targetUser);
            await _db.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Unsubscribe(SubscribeDto subscribeDto)
        {
            if (subscribeDto.CurrentNickName == subscribeDto.TargetNickName) return false;
            var currentUser = await _db.Users
                .SingleOrDefaultAsync(p => p.NickName.ToLower() == subscribeDto.CurrentNickName.ToLower());
            var targetUser =
                await _db.Users.SingleOrDefaultAsync(p => p.NickName.ToLower() == subscribeDto.TargetNickName.ToLower());
            currentUser.Subscriptions.Remove(subscribeDto.TargetNickName);
            targetUser.Subscribers.Remove(subscribeDto.CurrentNickName);
            _db.Users.Update(currentUser);
            _db.Users.Update(targetUser);
            await _db.SaveChangesAsync();
            return true;

        }
    }
}

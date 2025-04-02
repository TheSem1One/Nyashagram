using System.Linq.Expressions;
using User.Domain.DTO;
using User.Domain.Repositories;
using User.Infrastructure.Persistence;

namespace User.Infrastructure.Services
{
    public class ProfileService(UserContext db) : IProfile
    {
        private readonly UserContext _db = db;

        public Task<Domain.Entities.User> UpdateProfile(UserDTO userDto)
        {
            throw new NotImplementedException();
        }
    }
}

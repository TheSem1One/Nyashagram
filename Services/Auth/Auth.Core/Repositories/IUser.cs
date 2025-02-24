using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auth.Domain.Entities;
using Auth.Domain.Entities.AuthEntities;

namespace Auth.Domain.Repositories
{
    public interface IUser
    {
        Task<string> CreateUser(User user);
        Task<bool> UpdateUser(User user );
        Task<User> GetUserByName(string name);
    }
}

using Auth.Domain.DTO;
using Auth.Domain.Entities;

namespace Auth.Domain.Repositories
{
    public interface IAuth
    {
        Task<string> CreateUser(RegisterDTO registerDto);
        Task<string> LoginUser(LoginDTO loginDto);
        Task<bool> UpdateUser(User user);
        Task<User> GetUserByName(string name);
        Task<bool> UserExist(string email);
    }
}

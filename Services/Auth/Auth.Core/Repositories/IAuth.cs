using User.Domain.DTO;

namespace User.Domain.Repositories
{
    public interface IAuth
    {
        Task<string> CreateUser(RegisterDto registerDto);
        Task<string> LoginUser(LoginDto loginDto);
        Task<Entities.User> GetUserByName(string name);
    }
}

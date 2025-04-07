using User.Domain.DTO;
using User.Domain.DTO.Auth;

namespace User.Domain.Repositories
{
    public interface IAuth
    {
        Task<string> CreateUser(RegisterDto registerDto);
        Task<string> LoginUser(LoginDto loginDto);
    }
}

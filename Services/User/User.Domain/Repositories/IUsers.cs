using User.Domain.DTO;

namespace User.Domain.Repositories
{
    public interface IUsers
    {
        Task<UserDto> GetUserByNickName(string nickName);
        Task<FindDto> FindUser(string nickName);
    }
}

using User.Domain.DTO.Users;

namespace User.Domain.Repositories
{
    public interface IUsers
    {
        Task<GetUserDto> GetUserByNickName(string nickName);
        Task<IEnumerable<FindDto>> FindUser(string nickName);
        Task<bool> Subscribe(SubscribeDto subscribeDto);
        Task<bool> Unsubscribe(SubscribeDto subscribeDto);
    }
}

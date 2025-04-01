using User.Application.Responses;
using MediatR;

namespace User.Application.Queries
{
    public class GetUserQuery(string nickName) : IRequest<UserResponse>
    {
        public string NickName { get; set; } = nickName;
    }
}

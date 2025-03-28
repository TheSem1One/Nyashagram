using Auth.Application.Responses;
using MediatR;

namespace Auth.Application.Queries
{
    public class GetUserQuery : IRequest<UserResponse>
    {
        public string NickName { get; set; }
        public GetUserQuery(string nickName)
        {
            NickName = nickName;
        }
    }
}

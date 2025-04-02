using MediatR;
using User.Application.Mappers;
using User.Application.Responses;
using User.Domain.Repositories;

namespace User.Application.Features.Auth
{
    public class GetUserQuery : IRequest<UserResponse>
    {
        public string NickName { get; set; } = null!;
    }
    public class GetUserNickNameQueryHandler(IAuth auth) : IRequestHandler<GetUserQuery, UserResponse>
    {
        private readonly IAuth _auth = auth;

        public async Task<UserResponse> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _auth.GetUserByName(request.NickName);
            var userResponse = UserMapper.Mapper.Map<UserResponse>(user);
            return userResponse;
        }
    }
}

using User.Application.Mappers;
using User.Application.Queries;
using User.Application.Responses;
using User.Domain.Repositories;
using MediatR;

namespace User.Application.Handlers
{
    public class GetUserNickNameQueryHandler(IAuth user) : IRequestHandler<GetUserQuery, UserResponse>
    {
        private readonly IAuth _user = user;

        public async Task<UserResponse> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _user.GetUserByName(request.NickName);
            var userResponse = UserMapper.Mapper.Map<UserResponse>(user);
            return userResponse;
        }
    }
}

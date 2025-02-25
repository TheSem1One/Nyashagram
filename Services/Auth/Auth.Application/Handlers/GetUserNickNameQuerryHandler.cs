using Auth.Application.Mappers;
using Auth.Application.Queries;
using Auth.Application.Responses;
using Auth.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Auth.Application.Handlers
{
    public class GetUserNickNameQuerryHandler : IRequestHandler<GetUserQuery, UserResponse>
    {
        private readonly IAuth _user;
    
        public GetUserNickNameQuerryHandler(IAuth iUser, IMapper mapper)
        {
            
            _user = iUser;
        }

       async public Task<UserResponse> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _user.GetUserByName(request.NickName);
            var userResponse = UserMapper.Mapper.Map<UserResponse>(user);
            return userResponse;
        }
    }
}

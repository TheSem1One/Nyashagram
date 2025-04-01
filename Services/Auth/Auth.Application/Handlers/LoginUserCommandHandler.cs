using User.Application.Mappers;
using User.Application.Responses;
using User.Domain.DTO;
using User.Domain.Repositories;
using MediatR;
using User.Application.Commands;

namespace User.Application.Handlers
{
    class LoginUserCommandHandler(IAuth user) : IRequestHandler<LoginUserCommand, AuthResponse>
    {
        private readonly IAuth _user = user;

        public async Task<AuthResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var userEntity = UserMapper.Mapper.Map<LoginDto>(request);
            if (userEntity is null)
            {
                throw new ApplicationException("There is an issue with mapping while creating new User");
            }
            var authToken = await _user.LoginUser(userEntity);
            return new AuthResponse { Token = authToken };
        }
    }
}

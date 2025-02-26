using Auth.Application.Commands;
using Auth.Application.Mappers;
using Auth.Application.Responses;
using Auth.Domain.DTO;
using Auth.Domain.Repositories;
using MediatR;

namespace Auth.Application.Handlers
{
    class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, AuthResponse>
    {
        private IAuth _iuser;
        public LoginUserCommandHandler(IAuth iuser)
        {
            _iuser = iuser;
        }
        public async Task<AuthResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var userEntity = UserMapper.Mapper.Map<LoginDTO>(request);
            if (userEntity is null)
            {
                throw new ApplicationException("There is an issue with mapping while creating new User");
            }
            var authToken = await _iuser.LoginUser(userEntity);
            return new AuthResponse { Token = authToken };
        }
    }
}

using MediatR;
using User.Application.Mappers;
using User.Application.Responses;
using User.Domain.DTO;
using User.Domain.Repositories;

namespace User.Application.Features.Auth
{
    public class LoginUserCommand : IRequest<AuthResponse>
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

    }
    public class LoginUserCommandHandler(IAuth auth) : IRequestHandler<LoginUserCommand, AuthResponse>
    {
        private readonly IAuth _auth = auth;

        public async Task<AuthResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = UserMapper.Mapper.Map<LoginDto>(request);
            if (user is null)
            {
                throw new ApplicationException("There is an issue with mapping while creating new User");
            }
            var token = await _auth.LoginUser(user);
            return new AuthResponse { Token = token };
        }
    }

}

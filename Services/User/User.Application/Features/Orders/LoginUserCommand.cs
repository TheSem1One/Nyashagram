using MediatR;
using User.Application.Mappers;
using User.Application.Responses;
using User.Domain.DTO;
using User.Domain.Repositories;

namespace User.Application.Features.Orders
{
    public class LoginUserCommand : IRequest<AuthResponse>
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

    }
    public class LoginUserCommandHandler(IAuth user) : IRequestHandler<LoginUserCommand, AuthResponse>
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

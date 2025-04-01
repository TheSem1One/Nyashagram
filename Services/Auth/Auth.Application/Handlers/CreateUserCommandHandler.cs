using User.Application.Commands;
using User.Application.Mappers;
using User.Application.Responses;
using User.Domain.DTO;
using User.Domain.Repositories;
using MediatR;

namespace User.Application.Handlers
{
    public class CreateUserCommandHandler(IAuth user) : IRequestHandler<CreateUserCommand, AuthResponse>
    {
        private readonly IAuth _user = user;

        public async Task<AuthResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userEntity = UserMapper.Mapper.Map<RegisterDto>(request);
            if (userEntity is null)
            {
                throw new ApplicationException("There is an issue with mapping while creating new User");
            }
            var authToken = await _user.CreateUser(userEntity);
            return new AuthResponse { Token = authToken };
        }
    }
}

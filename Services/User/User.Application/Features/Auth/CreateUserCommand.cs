using MediatR;
using User.Application.Mappers;
using User.Application.Responses;
using User.Domain.DTO.Auth;
using User.Domain.Repositories;

namespace User.Application.Features.Auth
{
    public class CreateUserCommand : IRequest<string>
    {
        public string NickName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;


    }

    public class CreateUserCommandHandler(IAuth auth) : IRequestHandler<CreateUserCommand, string>
    {
        private readonly IAuth _auth = auth;

        public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = UserMapper.Mapper.Map<RegisterDto>(request);
            if (user is null)
            {
                throw new ApplicationException("There is an issue with mapping while creating new User");
            }
            var token = await _auth.CreateUser(user);
            return token;
        }
    }

}

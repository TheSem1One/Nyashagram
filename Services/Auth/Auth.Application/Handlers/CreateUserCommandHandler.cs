
using Auth.Application.Commands;
using Auth.Application.Mappers;
using Auth.Application.Responses;
using Auth.Domain.DTO;
using Auth.Domain.Entities;
using Auth.Domain.Repositories;
using MediatR;

namespace Auth.Application.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, RegisterResponse>
    {
        private IAuth _iuser;
        public CreateUserCommandHandler(IAuth iuser)
        {
            _iuser = iuser;
        }

     

        public async Task<RegisterResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userEntity = UserMapper.Mapper.Map<RegisterDTO>(request);
            if(userEntity is null)
            {
                throw new ApplicationException("There is an issue with mapping while creating new User");
            }
            var authToken = await _iuser.CreateUser(userEntity);
            return new RegisterResponse { Token = authToken };
        }
    }
}


using Auth.Application.Commands;
using Auth.Application.Mappers;
using Auth.Application.Responses;
using Auth.Domain.Entities;
using Auth.Domain.Repositories;
using MediatR;

namespace Auth.Application.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, RegisterResponse>
    {
        private IUser _iuser;
        public CreateUserCommandHandler(IUser iuser)
        {
            _iuser = iuser;
        }

     

        public async Task<RegisterResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userEntity = UserMapper.Mapper.Map<User>(request);
            if(userEntity is null)
            {
                throw new ApplicationException("There is an issue with mapping while creating new User");
            }
            var newUser = await _iuser.CreateUser(userEntity);
            var userResponse = UserMapper.Mapper.Map<RegisterResponse>(newUser);
            return userResponse;
        }
    }
}

 
using Auth.Application.Queries;
using Auth.Application.Responses;
using Auth.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Auth.Application.Handlers
{
    public class CreateUserQuerryHandler : IRequestHandler<CreateUserQuerry, RegisterResponse>
    {
        private readonly IUser _user;
        public CreateUserQuerryHandler(IUser iUser, IMapper mapper)
        {
            _user = iUser;
        }
        public Task<RegisterResponse> Handle(CreateUserQuerry request, CancellationToken cancellationToken)
        {
            var creatingUser = _user.CreateUser(request.NickName,request.Password,request.Email)
        }
    }
}

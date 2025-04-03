using MediatR;
using User.Domain.DTO.Users;
using User.Domain.Repositories;

namespace User.Application.Features.Users
{
    public class GetUsersByNickNameQuery : IRequest<GetUserDto>
    {
        public string NickName { get; set; }
    }
    public class GetUserByNickNameHandler(IUsers users) : IRequestHandler<GetUsersByNickNameQuery, GetUserDto>
    {
        private readonly IUsers _users = users;
        public async Task<GetUserDto> Handle(GetUsersByNickNameQuery request, CancellationToken cancellationToken)
        {
            var userDto = await _users.GetUserByNickName(request.NickName);
            return userDto;
        }
    }
}

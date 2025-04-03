using MediatR;
using User.Domain.DTO;
using User.Domain.DTO.Users;
using User.Domain.Repositories;

namespace User.Application.Features.Users
{
    public class FindUsersQuery : IRequest<IEnumerable<FindDto>>
    {
        public string NickName { get; set; } = null!;
    }

    public class FindUsersHandler(IUsers users) : IRequestHandler<FindUsersQuery, IEnumerable<FindDto>>
    {
        private readonly IUsers _users = users;
        public async Task<IEnumerable<FindDto>> Handle(FindUsersQuery request, CancellationToken cancellationToken)
        {
            return await _users.FindUser(request.NickName);
        }
    }
}

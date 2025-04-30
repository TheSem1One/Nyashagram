using MediatR;
using User.Application.Mappers;
using User.Domain.DTO;
using User.Domain.DTO.Users;
using User.Domain.Repositories;

namespace User.Application.Features.Profile
{
    public class SubscribeCommand : IRequest<bool>
    {
        public string CurrentNickName { get; set; } = null!;
        public string TargetNickName { get; set; } = null!;
    }

    public class SubscribeHandler (IUsers users) : IRequestHandler<SubscribeCommand, bool>
    {
        private readonly IUsers _users = users;
        public async Task<bool> Handle(SubscribeCommand request, CancellationToken cancellationToken)
        {
            var req = UserMapper.Mapper.Map<SubscribeDto>(request);
            return await _users.Subscribe(req);
        }
    }
}

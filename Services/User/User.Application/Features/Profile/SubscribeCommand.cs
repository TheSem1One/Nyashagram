using MediatR;
using User.Application.Mappers;
using User.Domain.DTO;
using User.Domain.Repositories;

namespace User.Application.Features.Profile
{
    public class SubscribeCommand : IRequest<bool>
    {
        public string CurrentName { get; set; } = null!;
        public string TargetName { get; set; } = null!;
    }

    public class SubscribeHandler(IProfile profile) : IRequestHandler<SubscribeCommand, bool>
    {
        private readonly IProfile _profile = profile;
        public async Task<bool> Handle(SubscribeCommand request, CancellationToken cancellationToken)
        {
            return await _profile.Subscribe(request.CurrentName,request.TargetName);
        }
    }
}

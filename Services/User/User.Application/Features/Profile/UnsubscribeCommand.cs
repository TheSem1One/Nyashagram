using MediatR;
using User.Domain.Repositories;

namespace User.Application.Features.Profile
{
    public class UnsubscribeCommand : IRequest<bool>
    {
        public string CurrentName { get; set; } = null!;
        public string TargetName { get; set; } = null!;
    }

    public class UnsubscribeHandler(IProfile profile) : IRequestHandler<UnsubscribeCommand, bool>
    {
        private readonly IProfile _profile = profile;
        public async Task<bool> Handle(UnsubscribeCommand request, CancellationToken cancellationToken)
        {
            return await _profile.Unsubscribe(request.CurrentName, request.TargetName);
        }
    }
}

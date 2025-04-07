using MediatR;
using User.Application.Mappers;
using User.Domain.DTO;
using User.Domain.DTO.Profile;
using User.Domain.Repositories;

namespace User.Application.Features.Story
{
    public class AddStoryCommand : IRequest<bool>
    {
        public string CreatorNickName { get; set; } = null!;
        public string Id { get; set; } = null!;
    }

    public class AddStoryHandler(IProfile profile) : IRequestHandler<AddStoryCommand, bool>
    {
        private readonly IProfile _profile = profile;
        public async Task<bool> Handle(AddStoryCommand request, CancellationToken cancellationToken)
        {
            var req = UserMapper.Mapper.Map<StoryDto>(request);
            return await _profile.AddStory(req);
        }
    }
}

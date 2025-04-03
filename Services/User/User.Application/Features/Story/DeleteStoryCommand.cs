using MediatR;
using User.Application.Mappers;
using User.Domain.DTO;
using User.Domain.Repositories;

namespace User.Application.Features.Story
{
    public class DeleteStoryCommand : IRequest<bool>
    {
        public string CreatorNickName { get; set; } = null!;
        public string Id { get; set; } = null!;
    }

    public class DeleteStoryHandler(IProfile profile) : IRequestHandler<DeleteStoryCommand, bool>
    {
        private readonly IProfile _profile = profile;
        public async Task<bool> Handle(DeleteStoryCommand request, CancellationToken cancellationToken)
        {
            var req = UserMapper.Mapper.Map<StoryDto>(request);
            return await _profile.DeleteStory(req);
        }
    }
}

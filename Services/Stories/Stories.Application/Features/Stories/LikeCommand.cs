using MediatR;
using Stories.Application.Mappers;
using Stories.Domain.Entity.DTO;
using Stories.Domain.Repositories;

namespace Stories.Application.Features.Stories
{
    public class LikeCommand : IRequest<bool>
    {
        public string StoryId { get; set; } = null!;
        public string NickName { get; set; } = null!;
    }

    public class LikeHandler(IStoriesRepository stories) : IRequestHandler<LikeCommand, bool>
    {
        private readonly IStoriesRepository _stories = stories;
        public async Task<bool> Handle(LikeCommand request, CancellationToken cancellationToken)
        {
            var req = StoryMapper.Mapper.Map<LikeDto>(request);
            return await _stories.Like(req);
        }
    }
}

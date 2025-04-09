using MediatR;
using Stories.Application.Mappers;
using Stories.Application.Responses;
using Stories.Domain.Entity.DTO;
using Stories.Domain.Repositories;

namespace Stories.Application.Features.Stories
{
    public class CreateStoryCommand : IRequest<CreateStoryResponse>
    {
        public string StoryImageUrl { get; set; } = null!;
        public string CreatorNickName { get; set; } = null!;
    }

    public class CreateStoryHandler(IStoriesRepository storiesRepository) : IRequestHandler<CreateStoryCommand, CreateStoryResponse>
    {
        private readonly IStoriesRepository _storyRepository = storiesRepository;

        public async Task<CreateStoryResponse> Handle(CreateStoryCommand request, CancellationToken cancellationToken)
        {
            var map = StoryMapper.Mapper.Map<CreateStoryCommand, ShortsDTO>(request);
            var createStory = await _storyRepository.CreateStory(map);
            return new CreateStoryResponse() { StoriesId = createStory };
        }
    }
}

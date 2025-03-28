using MediatR;
using Stories.Application.Commands;
using Stories.Application.Mappers;
using Stories.Application.Responses;
using Stories.Domain.Entity.DTO;
using Stories.Domain.Repositories;

namespace Stories.Application.Handles
{
    public class CreateStoryHandler : IRequestHandler<CreateStoryCommand, CreateStoryResponse>
    {
        private readonly IStoriesRepository _storyReposetory;

        public CreateStoryHandler(IStoriesRepository storiesRepository)
        {
            _storyReposetory = storiesRepository;
        }
        public async Task<CreateStoryResponse> Handle(CreateStoryCommand request, CancellationToken cancellationToken)
        {
            var map = StoryMapper.Mapper.Map<CreateStoryCommand, ShortsDTO>(request);
            var createStory = await _storyReposetory.CreateStories(map);
            return new CreateStoryResponse() { StoriesId = createStory };
        }
    }
}

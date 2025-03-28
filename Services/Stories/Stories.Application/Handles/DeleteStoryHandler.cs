using MediatR;
using Stories.Application.Queries;
using Stories.Application.Responses;
using Stories.Domain.Repositories;

namespace Stories.Application.Handles
{
    public class DeleteStoryHandler : IRequestHandler<DeleteStoryQuery, DeleteStoryResponse>
    {
        private readonly IStoriesRepository _storyReposetory;

        public DeleteStoryHandler(IStoriesRepository storiesRepository)
        {
            _storyReposetory = storiesRepository;
        }
        public async Task<DeleteStoryResponse> Handle(DeleteStoryQuery request, CancellationToken cancellationToken)
        {
            var delete = await _storyReposetory.DeleteStories(request.StoryId);
            return new DeleteStoryResponse { Status = delete };
        }
    }
}

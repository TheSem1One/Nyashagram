using MediatR;
using Stories.Application.Mappers;
using Stories.Application.Queries;
using Stories.Application.Responses;
using Stories.Domain.Entity;
using Stories.Domain.Repositories;

namespace Stories.Application.Handles
{
    class GetStoryByIdHandler(IStoriesRepository storiesRepository) : IRequestHandler<GetStoryByIdQuery, GetStoryByIdResponse>
    {
        private readonly IStoriesRepository _storiesRepository = storiesRepository;

        public async Task<GetStoryByIdResponse> Handle(GetStoryByIdQuery request, CancellationToken cancellationToken)
        {
            var story = await _storiesRepository.GetStoryById(request.StoryId);
            var mapResponse = StoryMapper.Mapper.Map<Short, GetStoryByIdResponse>(story);
            return mapResponse;
        }
    }
}

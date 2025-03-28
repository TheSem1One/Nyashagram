using MediatR;
using Stories.Application.Mappers;
using Stories.Application.Queries;
using Stories.Application.Responses;
using Stories.Domain.Entity;
using Stories.Domain.Repositories;

namespace Stories.Application.Handles
{
    public class GetStoryByCreatorHandler : IRequestHandler<GetStoryByCreatorQuery, IList<GetStoryResponse>>
    {
        private readonly IStoriesRepository _storiesRepository;
        public GetStoryByCreatorHandler(IStoriesRepository storiesRepository)
        {
            _storiesRepository = storiesRepository;
        }
        public async Task<IList<GetStoryResponse>> Handle(GetStoryByCreatorQuery request, CancellationToken cancellationToken)
        {
            var postList = await _storiesRepository.GetStoriesNickName(request.NickName);
            var storiesResponseList = StoryMapper.Mapper.Map<IList<Short>, IList<GetStoryResponse>>(postList.ToList());
            return storiesResponseList;
        }
    }
}

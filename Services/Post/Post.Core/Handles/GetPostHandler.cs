using AutoMapper;
using MediatR;
using Post.Application.Mappers;
using Post.Application.Queries;
using Post.Application.Responses;
using Post.Domain.Reposetories;

namespace Post.Application.Handles
{
    public class GetPostHandler : IRequestHandler<GetPostQuery, IList<GetPostResponse>>
    {
        private readonly IPostReposetory _postReposetory;
        public GetPostHandler(IPostReposetory postReposetory, IMapper mapper)
        {
            _postReposetory = postReposetory;
        }
        public async Task<IList<GetPostResponse>> Handle(GetPostQuery request, CancellationToken cancellationToken)
        {
            var postList = await _postReposetory.GetPost();
            var postResponseList = PostMapper.Mapper.Map<IList<Domain.Entities.Post>, IList<GetPostResponse>>(postList.ToList());
            return postResponseList;
        }

    }
}

using AutoMapper;
using MediatR;
using Post.Application.Mappers;
using Post.Application.Queries;
using Post.Application.Responses;
using Post.Domain.Reposetories;

namespace Post.Application.Handles
{
    public class GetPostByCreatorHandler : IRequestHandler<GetPostByCreatorQuery, IList<GetPostResponse>>
    {
        private readonly IPostRepository _postReposetory;
        public GetPostByCreatorHandler(IPostRepository postReposetory, IMapper mapper)
        {
            _postReposetory = postReposetory;
        }
        public async Task<IList<GetPostResponse>> Handle(GetPostByCreatorQuery request, CancellationToken cancellationToken)
        {
            var postList = await _postReposetory.GetPostByNickName(request.NickName);
            var postResponseList = PostMapper.Mapper.Map<IList<Domain.Entities.Post>, IList<GetPostResponse>>(postList.ToList());
            return postResponseList;
        }
    }
}

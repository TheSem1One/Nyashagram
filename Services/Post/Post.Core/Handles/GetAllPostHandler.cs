using AutoMapper;
using MediatR;
using Post.Application.Mappers;
using Post.Application.Queries;
using Post.Application.Responses;
using Post.Domain.Reposetories;

namespace Post.Application.Handles
{
    public class GetAllPostHandler : IRequestHandler<GetAllPostQuerry, IList<PostResponse>>
    {
        private readonly IPostReposetory _postReposetory;
        private readonly IMapper _mapper;
        public GetAllPostHandler(IPostReposetory postReposetory, IMapper mapper)
        {
            _postReposetory = postReposetory;
            _mapper = mapper;
        }
        public async Task<IList<PostResponse>> Handle(GetAllPostQuerry request, CancellationToken cancellationToken)
        {
            var postList = await _postReposetory.GetAllPost();
            var postResponseList = PostMapper.Mapper.Map<IList<Domain.Entities.Post>,IList<PostResponse>>(postList.ToList());
            return postResponseList;
        }
    }
}
